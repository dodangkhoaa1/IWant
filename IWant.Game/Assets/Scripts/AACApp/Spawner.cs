using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AACWordSpawner : MonoBehaviour
{
    private readonly Color yellowColor = new Color32(254, 218, 21, 255); //#FEDA15


    [Header("Word")]
    [SerializeField] GameObject wordContainer;
    [SerializeField] Button wordButtonPrefab;

    [Header("Category")]
    [SerializeField] GameObject categoryContainer;
    [SerializeField] Button categoryButtonPrefab;

    [Header("Others")]
    [SerializeField] GameObject phraseBuildGO;

    private PhraseBuild phraseBuild;
    private Button currentCategoryButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phraseBuild = phraseBuildGO.GetComponent<PhraseBuild>();

        StartCoroutine(InitializeLocalization());
    }

    private IEnumerator InitializeLocalization()
    {
        yield return StartCoroutine(SpawnWords());
        yield return StartCoroutine(SpawnWordCategories());
    }

    public IEnumerator SpawnWords(int categoryId = 1)
    {
        UnityWebRequest request = new UnityWebRequest(AddressAPI.WORD_URL, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            List<WordDTO> words = JsonConvert.DeserializeObject<List<WordDTO>>(responseText);
            foreach (Transform child in wordContainer.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (var word in words)
            {
                if (word.WordCategoryId == categoryId)
                {
                    Button newTTSBtn = Instantiate(wordButtonPrefab, wordContainer.transform, false);
                    newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? word.VietnameseText : word.EnglishText;
                    //set display name for game object
                    newTTSBtn.name = word.EnglishText;
                    // Convert byte array to sprite
                    if (word.Image != null && word.Image.Length > 0)
                    {
                        Sprite sprite = Convert.ConvertBytesToSprite(word.Image);
                        if (sprite != null)
                        {
                            Image childImage = newTTSBtn.transform.Find("Image").GetComponent<Image>();
                            childImage.sprite = sprite;
                        }
                        else
                        {
                            Debug.LogWarning($"Failed to convert image for word: {word.EnglishText}");
                        }
                    }

                    newTTSBtn.GetComponent<Button>().onClick.AddListener(() => phraseBuild.AddToList(newTTSBtn.gameObject));
                }
            }
        }
        else
        {
            Debug.Log(request.responseCode);
        }
    }

    public IEnumerator SpawnWordCategories()
    {
        UnityWebRequest request = new UnityWebRequest(AddressAPI.WORD_CATEGORY_URL, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            List<WordCategoryDTO> wordCategories = JsonConvert.DeserializeObject<List<WordCategoryDTO>>(responseText);
            foreach (var category in wordCategories)
            {
                Button newTTSBtn = Instantiate(categoryButtonPrefab, categoryContainer.transform, false);
                newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? category.VietnameseName : category.EnglishName;
                // Convert byte array to sprite
                if (category.Image != null && category.Image.Length > 0)
                {

                    Sprite sprite = Convert.ConvertBytesToSprite(category.Image);
                    if (sprite != null)
                    {
                        Image childImage = newTTSBtn.transform.Find("Image").GetComponent<Image>();
                        childImage.sprite = sprite;
                    }
                    else
                    {
                        Debug.LogWarning($"Failed to convert image for word: {category.EnglishName}");
                    }
                }

                newTTSBtn.GetComponent<Button>().onClick.AddListener(() =>
                {
                    StartCoroutine(SpawnWords(category.Id));
                    HighlightCategoryButton(newTTSBtn);
                });
            }
            HighlightCategoryButton(categoryContainer.transform.GetChild(0).GetComponent<Button>());
        }
        else
        {
            Debug.Log(request.responseCode);
        }
    }

    private void HighlightCategoryButton(Button selectedButton)
    {
        if (currentCategoryButton != null)
        {
            currentCategoryButton.GetComponent<Image>().color = Color.white;
        }
        currentCategoryButton = selectedButton;
        currentCategoryButton.GetComponent<Image>().color = yellowColor;
    }
}
