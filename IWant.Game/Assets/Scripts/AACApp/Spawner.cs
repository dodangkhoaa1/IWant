﻿using EasyUI.Toast;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AACWordSpawner : MonoBehaviour
{
    [SerializeField] private Color yellowColor = new Color32(255, 241, 136, 255); //#FFF188

    [Header("Suggestion")]
    [SerializeField] Sprite suggestCategoryWordSprite;
    [SerializeField] SuggestWordData[] suggestWordList;

    [Header("Word")]
    [SerializeField] GameObject wordContainer;
    [SerializeField] Button wordButtonPrefab;

    [Header("Category")]
    [SerializeField] GameObject categoryContainer;
    [SerializeField] Button categoryButtonPrefab;
    [SerializeField] Sprite allCategorySprite;

    [Header("Others")]
    [SerializeField] GameObject phraseBuildGO;

    [Header("Scroll View")]
    [SerializeField] ScrollRect categoryScrollRect;

    [Header("Loading Management")]
    public LoadingManagement loadingManagement;

    [Header("Move To All Category")]
    [SerializeField] Button moveToAllCateBtn;

    private PhraseBuild phraseBuild;
    private Button currentCategoryButton;
    private List<WordDTO> personalWords;
    private List<WordDTO> words;
    private List<WordCategoryDTO> wordCategories;

    //[SerializeField] TextToSpeech toSpeech;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phraseBuild = phraseBuildGO.GetComponent<PhraseBuild>();

        StartCoroutine(InitializeLocalization());

        moveToAllCateBtn.onClick.AddListener(() =>
        {
            Button allCategoryButton = categoryContainer.transform.GetChild(1).GetComponent<Button>();
            if (allCategoryButton != null)
            {
                allCategoryButton.onClick.Invoke();
            }
        });
    }

    private void Update()
    {
        CheckAndDisableSuggestionButtons();
        UpdateMoveToTopButton(0.3f);

    }

    private void CheckAndDisableSuggestionButtons()
    {
        if (words == null) return;
        foreach (var suggestWord in suggestWordList)
        {
            bool allWordsExist = true;
            foreach (int wordId in suggestWord.aacWordsId)
            {
                WordDTO word = words.Find(w => w.Id == wordId);
                if (word == null || phraseBuild.ContainsWord(word.EnglishText) == null)
                {
                    allWordsExist = false;
                    break;
                }
            }

            Button suggestionButton = wordContainer.transform.Find(suggestWord.EnglishText)?.GetComponent<Button>();
            if (suggestionButton != null)
            {
                suggestionButton.interactable = !allWordsExist;
            }
        }
    }

    // Allow to initialize localization settings and spawn word categories and personal words
    private IEnumerator InitializeLocalization()
    {
        loadingManagement.EnableLoadingPanel();
        yield return StartCoroutine(LoadWordsFromAPI());
        yield return StartCoroutine(LoadPersonalWordsFromAPI());
        yield return StartCoroutine(SpawnWordCategories());
        loadingManagement.DisableLoadingPanel();

        // Download all audio for words and categories
        //yield return StartCoroutine(toSpeech.DownloadAllAudio(words, wordCategories));

        CreateSuggestionButtons();
    }

    // Allow to spawn personal words for a specific user
    public void SpawnPersonalWords()
    {
        if (personalWords.Count == 0)
        {
            string toastStr = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? "List Is Empty!" : "Danh Sách Trống!";
            Toast.Show(toastStr, ToastColor.Yellow, ToastPosition.BottomCenter);
        }
        SpawnWords(personalWords, 1);
    }

    // Load personal words from API
    private IEnumerator LoadPersonalWordsFromAPI()
    {
        UnityWebRequest request = new UnityWebRequest($"{AddressAPI.WORD_URL}/user/{DBManager.User.UserId}", "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            personalWords = JsonConvert.DeserializeObject<List<WordDTO>>(responseText);

            if (personalWords.Count == 0)
            {
                //Toast.Show("Personal Word List Is Empty!", Color.yellow, ToastPosition.BottomCenter);
                yield return null;
            }
        }
        else
        {
            Debug.Log(request.responseCode);
        }
    }

    // Allow to spawn words for a specific category
    public void SpawnWords(int categoryId)
    {
        SpawnWords(words, categoryId);
    }

    // Load words from API
    private IEnumerator LoadWordsFromAPI()
    {
        UnityWebRequest request = new UnityWebRequest(AddressAPI.WORD_URL, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            words = JsonConvert.DeserializeObject<List<WordDTO>>(responseText);
        }
        else
        {
            Debug.Log(request.responseCode);
        }
    }

    // Spawn words
    private void SpawnWords(List<WordDTO> words, int categoryId = -1)
    {
        foreach (Transform child in wordContainer.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var word in words)
        {
            if (categoryId == -1 || word.WordCategoryId == categoryId)
            {
                Button newTTSBtn = Instantiate(wordButtonPrefab, wordContainer.transform, false);
                newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? word.VietnameseText : word.EnglishText;
                //set display name for game object
                newTTSBtn.name = word.EnglishText;

                // Convert Image to sprite
                if (word.ImagePath != null)
                {
                    StartCoroutine(Convert.LoadImage(word.ImagePath, (sprite) =>
                    {
                        if (sprite != null)
                        {
                            if (newTTSBtn != null)
                            {
                                Image childImage = newTTSBtn.transform.Find("Image").GetComponent<Image>();
                                childImage.sprite = sprite;
                            }
                        }
                        else
                        {
                            Debug.LogWarning($"Failed to convert image for word: {word.EnglishText}");
                        }
                    }, 0f));
                }

                // Check if the word is already in the phrase build
                if (phraseBuild.ContainsWord(word.EnglishText) != null)
                {
                    newTTSBtn.interactable = false;
                }

                newTTSBtn.GetComponent<Button>().onClick.AddListener(() =>
                {
                    phraseBuild.AddToList(newTTSBtn.gameObject, (instance) =>
                    {
                        //Convert Image to sprite
                        if (word.ImagePath != null)
                        {
                            StartCoroutine(Convert.LoadImage(word.ImagePath, (sprite) =>
                            {
                                if (sprite != null)
                                {
                                    Image childImage = instance.transform.Find("Image").GetComponent<Image>();
                                    childImage.sprite = sprite;

                                }
                                else
                                {
                                    Debug.LogWarning($"Failed to convert image for word: {word.EnglishText}");
                                }
                            }));
                        }
                    });
                });
            }
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
            wordCategories = JsonConvert.DeserializeObject<List<WordCategoryDTO>>(responseText);
            foreach (Transform child in wordContainer.transform)
            {
                Destroy(child.gameObject);
            }
            for (int i = wordCategories.Count - 1; i >= 0; i--)
            {
                var category = wordCategories[i];
                Button newTTSBtn = Instantiate(wordButtonPrefab, wordContainer.transform, false);
                newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? category.VietnameseName : category.EnglishName;
                //set display name for game object
                newTTSBtn.name = category.EnglishName;

                if (category.ImagePath != null)
                {
                    StartCoroutine(Convert.LoadImage(category.ImagePath, (sprite) =>
                    {
                        if (sprite != null)
                        {
                            if (newTTSBtn != null)
                            {
                                Image childImage = newTTSBtn.transform.Find("Image").GetComponent<Image>();
                                childImage.sprite = sprite;
                            }
                        }
                        else
                        {
                            Debug.LogWarning($"Failed to convert image for word: {category.EnglishName}");
                        }
                    }));
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
                    if (category.Id == 1)
                    {
                        SpawnPersonalWords();
                    }
                    else
                    {
                        SpawnWords(category.Id);
                    }
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
            Image allCategoriesImage = allCategoriesBtn.transform.Find("Image").GetComponent<Image>();
            allCategoriesImage.sprite = allCategorySprite;
            allCategoriesBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? "Tất cả" : "All Categories";

            allCategoriesBtn.GetComponent<Button>().onClick.AddListener(() =>
            {
                StartCoroutine(SpawnAllCatetgories());
                HighlightCategoryButton(allCategoriesBtn);
            });

            // Tạo nút "Suggestion Sents" (Category của Category)
            Button suggestionSentsBtn = Instantiate(categoryButtonPrefab, categoryContainer.transform, false);
            Image suggestionSentsImage = suggestionSentsBtn.transform.Find("Image").GetComponent<Image>();
            suggestionSentsImage.sprite = suggestCategoryWordSprite;
            suggestionSentsBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? "Đề Xuất" : "Suggestion Sents";
            suggestionSentsBtn.GetComponent<Button>().onClick.AddListener(() =>
            {
                // Add logic to handle "Suggestion Sents" button click
                CreateSuggestionButtons();
                HighlightCategoryButton(suggestionSentsBtn);
            });

            // Đặt nút "Suggestion Sents" lên đầu danh sách
            suggestionSentsBtn.transform.SetAsFirstSibling();

            foreach (var category in wordCategories)
            {
                Button newTTSBtn = Instantiate(categoryButtonPrefab, categoryContainer.transform, false);
                newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? category.VietnameseName : category.EnglishName;

                if (category.ImagePath != null)
                {
                    StartCoroutine(Convert.LoadImage(category.ImagePath, (sprite) =>
                    {
                        if (sprite != null)
                        {
                            Image childImage = newTTSBtn.transform.Find("Image").GetComponent<Image>();
                            childImage.sprite = sprite;
                        }
                        else
                        {
                            Debug.LogWarning($"Failed to convert image for word: {category.EnglishName}");
                        }
                    }));
                }

                newTTSBtn.GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (category.Id == 1)
                    {
                        SpawnPersonalWords();
                    }
                    else
                    {
                        SpawnWords(category.Id);
                    }
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
    private void CreateSuggestionButtons()
    {
        foreach (Transform child in wordContainer.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var suggestWord in suggestWordList)
        {
            Button newSuggestBtn = Instantiate(wordButtonPrefab, wordContainer.transform, false);
            newSuggestBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? suggestWord.VietnameseText : suggestWord.EnglishText;
            newSuggestBtn.name = suggestWord.EnglishText;

            if (suggestWord.groupWordSprite != null)
            {
                Image childImage = newSuggestBtn.transform.Find("Image").GetComponent<Image>();
                childImage.sprite = suggestWord.groupWordSprite;
            }

            newSuggestBtn.GetComponent<Button>().onClick.AddListener(() =>
            {
                foreach (int wordId in suggestWord.aacWordsId)
                {
                    WordDTO word = words.Find(w => w.Id == wordId);

                    // Remove the word button from phraseContainer if it already exists
                    string textToCheck = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? word.EnglishText : word.VietnameseText;
                    Transform exitedWord = phraseBuild.ContainsWord(textToCheck);
                    if (exitedWord != null)
                    {
                        StartCoroutine(phraseBuild.RemoveFromList(exitedWord.gameObject));

                        Debug.Log($"Removed {exitedWord.name}");
                    }

                    if (word != null)
                    {
                        GameObject wordButtonInstance = Instantiate(wordButtonPrefab.gameObject);
                        wordButtonInstance.name = word.EnglishText;
                        wordButtonInstance.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? word.EnglishText : word.VietnameseText;
                        phraseBuild.AddToList(wordButtonInstance, (instance) =>
                        {
                            //Convert Image to sprite
                            if (word.ImagePath != null)
                            {
                                StartCoroutine(Convert.LoadImage(word.ImagePath, (sprite) =>
                                {
                                    if (sprite != null)
                                    {
                                        Image childImage = instance.transform.Find("Image").GetComponent<Image>();
                                        childImage.sprite = sprite;

                                    }
                                    else
                                    {
                                        Debug.LogWarning($"Failed to convert image for word: {word.EnglishText}");
                                    }
                                }));
                            }
                        });


                        // Disable the original button in the suggestion list
                        newSuggestBtn.interactable = false;

                        if (suggestWord.nextCategoryId != 0)
                        {
                            SpawnWords(suggestWord.nextCategoryId);

                            //get corresponding child 
                            int indexOfCategoryInContainer = suggestWord.nextCategoryId + 1;
                            // Highlight the corresponding category button
                            Button correspondingCategoryButton = categoryContainer.transform.GetChild(suggestWord.nextCategoryId + 1).GetComponent<Button>();
                            if (correspondingCategoryButton != null)
                            {
                                HighlightCategoryButton(correspondingCategoryButton);
                            }
                        }
                    }
                }
            });
        }
    }

    private void UpdateMoveToTopButton(float secondToFade = 0.5f)
    {
        float xPosition = categoryScrollRect.content.anchoredPosition.x;
        if (xPosition <= -800)
        {
            StartCoroutine(FadeInButton(moveToAllCateBtn, secondToFade));
        }
        else
        {
            StartCoroutine(FadeOutButton(moveToAllCateBtn, secondToFade));
        }
    }

    private IEnumerator FadeInButton(Button button, float secondToFade)
    {
        button.gameObject.SetActive(true);
        Image buttonImage = button.GetComponent<Image>();
        Color buttonColor = buttonImage.color;
        float alpha = buttonColor.a;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime / secondToFade; // 0.5 seconds to fade in
            buttonColor.a = Mathf.Clamp01(alpha);
            buttonImage.color = buttonColor;
            yield return null;
        }

        button.interactable = true;
    }

    private IEnumerator FadeOutButton(Button button, float secondToFade)
    {
        Image buttonImage = button.GetComponent<Image>();
        Color buttonColor = buttonImage.color;
        float alpha = buttonColor.a;

        while (alpha > 0f)
        {
            alpha -= Time.deltaTime / secondToFade; // 0.5 seconds to fade out
            buttonColor.a = Mathf.Clamp01(alpha);
            buttonImage.color = buttonColor;
            yield return null;
        }

        button.gameObject.SetActive(false);
        button.interactable = false;
    }
}
