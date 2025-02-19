using EasyUI.Toast;
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

    [Header("Scroll View")]
    [SerializeField] ScrollRect categoryScrollRect;

    private PhraseBuild phraseBuild;
    private Button currentCategoryButton;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phraseBuild = phraseBuildGO.GetComponent<PhraseBuild>();

        StartCoroutine(InitializeLocalization());
    }

    // Allow to initialize localization settings and spawn word categories and personal words
    private IEnumerator InitializeLocalization()
    {
        yield return StartCoroutine(SpawnWordCategories());
        yield return StartCoroutine(SpawnAllCatetgories());
        //yield return StartCoroutine(SpawnPersonalWords());
    }

    // Allow to spawn personal words for a specific user
    public IEnumerator SpawnPersonalWords(string userId = "0bcbb4f7-72f9-435f-9cb3-1621b4503974")
    {
        UnityWebRequest request = new UnityWebRequest(AddressAPI.PERSONAL_WORD_URL + "?userId=" + userId, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            List<WordDTO> personalWords = JsonConvert.DeserializeObject<List<WordDTO>>(responseText);

            if (personalWords.Count == 0)
            {
                StartCoroutine(SpawnWords());

                Toast.Show("There no personal word", Color.yellow, ToastPosition.BottomCenter);
                yield return null;
            }
            foreach (Transform child in wordContainer.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var word in personalWords)
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
        else
        {
            Debug.Log(request.responseCode);
        }
    }

    // Allow to spawn words for a specific category
    public IEnumerator SpawnWords(int categoryId = 2)
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

    // Allow to spawn all word categories
    public IEnumerator SpawnAllCatetgories()
    {
        UnityWebRequest request = new UnityWebRequest(AddressAPI.WORD_CATEGORY_URL, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            List<WordCategoryDTO> wordCategories = JsonConvert.DeserializeObject<List<WordCategoryDTO>>(responseText);
            foreach (Transform child in wordContainer.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (var category in wordCategories)
            {
                Button newTTSBtn = Instantiate(wordButtonPrefab, wordContainer.transform, false);
                newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? category.VietnameseName : category.EnglishName;
                //set display name for game object
                newTTSBtn.name = category.EnglishName;
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

                // Tìm nút danh mục tương ứng trong categoryContainer
                Button correspondingCategoryButton = null;
                foreach (Transform child in categoryContainer.transform)
                {
                    if (child.GetComponentInChildren<TextMeshProUGUI>().text == newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text)
                    {
                        correspondingCategoryButton = child.GetComponent<Button>();
                        break;
                    }
                }

                newTTSBtn.GetComponent<Button>().onClick.AddListener(() =>
                {
                    StartCoroutine(SpawnWords(category.Id));
                    if (correspondingCategoryButton != null)
                    {
                        HighlightCategoryButton(correspondingCategoryButton);
                    }
                });
            }

        }
        else
        {
            Debug.Log(request.responseCode);
        }
    }

    // Allow to spawn word categories
    public IEnumerator SpawnWordCategories()
    {
        UnityWebRequest request = new UnityWebRequest(AddressAPI.WORD_CATEGORY_URL, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            List<WordCategoryDTO> wordCategories = JsonConvert.DeserializeObject<List<WordCategoryDTO>>(responseText);


            // Xóa các category cũ
            foreach (Transform child in categoryContainer.transform)
            {
                Destroy(child.gameObject);
            }

            // Tạo nút "All Categories" (Category của Category)
            Button allCategoriesBtn = Instantiate(categoryButtonPrefab, categoryContainer.transform, false);
            allCategoriesBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? "Tất cả" : "All Categories";

            allCategoriesBtn.GetComponent<Button>().onClick.AddListener(() =>
            {
                StartCoroutine(SpawnAllCatetgories());
                HighlightCategoryButton(allCategoriesBtn);
            });


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

    // Allow to highlight the selected category button
    private void HighlightCategoryButton(Button selectedButton)
    {
        if (currentCategoryButton != null)
        {
            currentCategoryButton.GetComponent<Image>().color = Color.white;
        }
        currentCategoryButton = selectedButton;
        currentCategoryButton.GetComponent<Image>().color = yellowColor;

        // Scroll to the selected button
        ScrollToSelected(selectedButton);
    }

    private void ScrollToSelected(Button selectedButton)
    {
        // x của nút đó - độ dài của nó chia 2
        RectTransform selectedRectTransform = selectedButton.GetComponent<RectTransform>();
        RectTransform contentRectTransform = categoryScrollRect.content;
        RectTransform viewportRectTransform = categoryScrollRect.viewport;

        // Lấy kích thước của viewport và content
        float viewportWidth = viewportRectTransform.rect.width;
        float contentWidth = contentRectTransform.rect.width;

        float selectedX = selectedRectTransform.anchoredPosition.x;

        //float targetPosition = -selectedX + buttonWidth + 240;
        float targetPosition = -selectedX + (viewportWidth / 2);

        // Đảm bảo không cuộn ra ngoài giới hạn
        float minScroll = 0; // Giới hạn trái
        float maxScroll = contentWidth - viewportWidth; // Giới hạn phải
        targetPosition = Mathf.Clamp(targetPosition, -maxScroll, minScroll);

        // Cập nhật vị trí cuộn
        contentRectTransform.anchoredPosition = new Vector2(targetPosition, contentRectTransform.anchoredPosition.y);
    }


}
