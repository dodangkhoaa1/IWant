using EasyUI.Toast;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PersonalWordManagement : MonoBehaviour
{
    [Header("Personal Word")]
    [SerializeField] GameObject wordContainer;
    [SerializeField] Button wordButtonPrefab;

    [Header("Create Personal Word")]
    [SerializeField] Image displaySelectedImage;
    [SerializeField] Button choosePhotoFromLibraryBtn;
    [SerializeField] TMP_InputField englishText;
    [SerializeField] TMP_InputField vietnameseText;
    [SerializeField] Button createPersonalBtn;
    [SerializeField] GameObject createPersonalPanel;

    private List<WordDTO> personalWords;

    private void Start()
    {
        StartCoroutine(Initialize());
        choosePhotoFromLibraryBtn.onClick.AddListener(OnChoosePhotoFromLibraryBtnClicked);
        createPersonalBtn.onClick.AddListener(OnCreatePersonalBtnClicked);
    }

    private IEnumerator Initialize()
    {
        yield return StartCoroutine(LoadPersonalWordsFromAPI());
        SpawnPersonalWords();
    }

    private IEnumerator LoadPersonalWordsFromAPI()
    {
        UnityWebRequest request = new UnityWebRequest(AddressAPI.PERSONAL_WORD_URL + "?userId=" + DBManager.User.UserId, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            personalWords = JsonConvert.DeserializeObject<List<WordDTO>>(responseText);

            if (personalWords.Count == 0)
            {
                Toast.Show("There no personal word", ToastColor.Yellow, ToastPosition.BottomCenter);
                yield return null;
            }
        }
        else
        {
            Debug.Log(request.responseCode);
        }
    }

    private void SpawnPersonalWords()
    {
        if (personalWords == null)
        {
            Debug.LogError("personalWords is null. Ensure LoadPersonalWordsFromAPI is called and completed successfully.");
            return;
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

            // Add delete button event
            Button deleteButton = newTTSBtn.transform.Find("DeleteButton").GetComponent<Button>();
            deleteButton.onClick.AddListener(() => StartCoroutine(DeleteWord(word.Id, newTTSBtn.gameObject)));
        }
    }

    private IEnumerator DeleteWord(int wordId, GameObject wordButton)
    {
        UnityWebRequest request = UnityWebRequest.Delete(AddressAPI.PERSONAL_WORD_URL + "/" + wordId);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Destroy(wordButton);
            Toast.Show("Word deleted successfully", ToastColor.Green, ToastPosition.BottomCenter);
        }
        else
        {
            Debug.LogError("Failed to delete word: " + request.error);
            Toast.Show("Failed to delete word", ToastColor.Red, ToastPosition.BottomCenter);
        }
    }

    private void OnChoosePhotoFromLibraryBtnClicked()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            PickImageFromFileExplorer();
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
            {
                Permission.RequestUserPermission(Permission.ExternalStorageRead);
            }
            else
            {
                PickImageFromGallery();
            }
        }
    }

    private void PickImageFromGallery()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                Texture2D texture = NativeGallery.LoadImageAtPath(path, -1);
                if (texture != null)
                {
                    displaySelectedImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                }
                else
                {
                    Debug.LogError("Couldn't load texture from " + path);
                }
            }
        }, "Select an image", "image/*");

        if (permission == NativeGallery.Permission.ShouldAsk)
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
        }
    }

    private void PickImageFromFileExplorer()
    {
        string path = UnityEditor.EditorUtility.OpenFilePanel("Select an image", "", "png,jpg,jpeg");
        if (!string.IsNullOrEmpty(path))
        {
            byte[] fileData = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
            displaySelectedImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }

    private void OnCreatePersonalBtnClicked()
    {
        if (displaySelectedImage.sprite == null || string.IsNullOrEmpty(englishText.text) || string.IsNullOrEmpty(vietnameseText.text))
        {
            Toast.Show("Please fill in all fields and select an image.", ToastColor.Red, ToastPosition.BottomCenter);
            return;
        }

        StartCoroutine(CreatePersonalWord());
    }

    private IEnumerator CreatePersonalWord()
    {
        PersonalWordDTO newWord = new PersonalWordDTO
        {
            EnglishText = englishText.text,
            VietnameseText = vietnameseText.text,
            UserId = DBManager.User.UserId,
            Image = displaySelectedImage.sprite.texture.EncodeToPNG()
        };

        string jsonData = JsonConvert.SerializeObject(newWord);
        UnityWebRequest request = new UnityWebRequest(AddressAPI.PERSONAL_WORD_URL, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Toast.Show("Personal word created successfully", ToastColor.Green, ToastPosition.BottomCenter);
            StartCoroutine(Initialize());
            createPersonalPanel.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Failed to create personal word: " + request.error);
            Toast.Show("Failed to create personal word", ToastColor.Red, ToastPosition.BottomCenter);
        }
    }
}

