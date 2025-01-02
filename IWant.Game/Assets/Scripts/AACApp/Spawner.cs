using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AACWordSpawner : MonoBehaviour
{
    [Header("Word")]
    [SerializeField] GameObject wordContainer;
    [SerializeField] Button wordButtonPrefab;

    [Header("Category")]
    [SerializeField] GameObject categoryContainer;
    [SerializeField] Button categoryButtonPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnWords());
        StartCoroutine(SpawnWordCategories());

    }

    public IEnumerator SpawnWords()
    {

        UnityWebRequest request = new UnityWebRequest(AddressAPI.WORD_URL, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);
            List<WordDTO> words = JsonConvert.DeserializeObject<List<WordDTO>>(responseText);
            foreach (var word in words)
            {
                Button newTTSBtn = Instantiate(wordButtonPrefab, wordContainer.transform, false);

                newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? word.VietnameseText : word.EnglishText;

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
            Debug.Log(responseText);
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
            }

        }
        else
        {
            Debug.Log(request.responseCode);
        }
    }
}