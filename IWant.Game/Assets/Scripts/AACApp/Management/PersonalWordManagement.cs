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

    [Header("Loading Management")]
    public LoadingManagement loadingManagement;

    private List<WordDTO> words;

    private void Start()
    {
        StartCoroutine(Initialize());
        choosePhotoFromLibraryBtn.onClick.AddListener(OnChoosePhotoFromLibraryBtnClicked);
        createPersonalBtn.onClick.AddListener(OnCreatePersonalBtnClicked);
    }

    private IEnumerator Initialize()
    {
        loadingManagement.EnableLoadingPanel();
        yield return StartCoroutine(LoadPersonalWordsFromAPI());
        SpawnPersonalWords();
        loadingManagement.DisableLoadingPanel();
    }

    private IEnumerator LoadPersonalWordsFromAPI()
    {
        UnityWebRequest request = new UnityWebRequest($"{AddressAPI.WORD_URL}/user/{DBManager.User.UserId}", "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            words = JsonConvert.DeserializeObject<List<WordDTO>>(responseText);

            if (words.Count == 0)
            {
                string toastStr = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? "List Is Empty!" : "Danh Sách Trống!";
                Toast.Show(toastStr, ToastColor.Yellow, ToastPosition.BottomCenter);
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
        if (words == null)
        {
            Debug.LogError("personalWords is null. Ensure LoadPersonalWordsFromAPI is called and completed successfully.");
            return;
        }

        foreach (Transform child in wordContainer.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var word in words)
        {
            Button newTTSBtn = Instantiate(wordButtonPrefab, wordContainer.transform, false);
            newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? word.VietnameseText : word.EnglishText;
            //set display name for game object
            newTTSBtn.name = word.EnglishText;

            //Convert Image to sprite
            if (word.ImagePath != null)
            {
                StartCoroutine(Convert.LoadImage(word.ImagePath, (sprite) =>
                {
                    if (sprite != null)
                    {
                        Image childImage = newTTSBtn.transform.Find("Image").GetComponent<Image>();
                        childImage.sprite = sprite;
                    }
                    else
                    {
                        Debug.LogWarning($"Failed to convert image for word: {word.EnglishText}");
                    }
                }));
            }

            // Add delete button event
            Button deleteButton = newTTSBtn.transform.Find("DeleteButton").GetComponent<Button>();
            deleteButton.onClick.AddListener(() => StartCoroutine(DeleteWord(word.Id, newTTSBtn.gameObject)));
        }
    }

    private IEnumerator DeleteWord(int wordId, GameObject wordButton)
    {
        loadingManagement.EnableLoadingPanel();
        UnityWebRequest request = UnityWebRequest.Delete(AddressAPI.WORD_URL + "/" + wordId);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Destroy(wordButton);
            Toast.Show("Delete Word Successfully!", ToastColor.Green, ToastPosition.BottomCenter);
        }
        else
        {
            Debug.LogError("Failed to delete word: " + request.error);
            Toast.Show("Delete Word Fail!", ToastColor.Red, ToastPosition.BottomCenter);
        }
        loadingManagement.DisableLoadingPanel();

    }

    private void OnChoosePhotoFromLibraryBtnClicked()
    {
        //PickImageFromGallery();
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
            {
                Permission.RequestUserPermission(Permission.ExternalStorageRead);
                StartCoroutine(CheckPermissionAndPickImage());
            }
            else
            {
                PickImageFromGallery();
            }
        }
        //else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        //{
        //    PickImageFromFileExplorer();
        //}
    }

    private IEnumerator CheckPermissionAndPickImage()
    {
        while (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            yield return null;
        }
        PickImageFromGallery();
    }

    private void PickImageFromGallery()
    {

        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                Texture2D texture = NativeGallery.LoadImageAtPath(imagePath: path, markTextureNonReadable: false);
                if (texture != null)
                {
                    displaySelectedImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                }
                else
                {
                    Toast.Show("Load Image Fail!", ToastColor.Red, ToastPosition.BottomCenter);
                }
            }
        }, "Select an image", "image/*");

        if (permission == NativeGallery.Permission.ShouldAsk)
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
        }


    }

    //private void PickImageFromFileExplorer()
    //{
    //    string path = UnityEditor.EditorUtility.OpenFilePanel("Select an image", "", "png,jpg,jpeg");
    //    if (!string.IsNullOrEmpty(path))
    //    {
    //        byte[] fileData = System.IO.File.ReadAllBytes(path);
    //        Texture2D texture = new Texture2D(2, 2);
    //        texture.LoadImage(fileData);
    //        displaySelectedImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    //    }
    //}

    private void OnCreatePersonalBtnClicked()
    {
        if (displaySelectedImage.sprite == null || string.IsNullOrEmpty(englishText.text) || string.IsNullOrEmpty(vietnameseText.text))
        {
            string toastStr = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? "All fields are required!" : "Tất cả các trường là bắt buộc!";
            Toast.Show(toastStr, ToastColor.Red, ToastPosition.BottomCenter);
            return;
        }

        StartCoroutine(CreatePersonalWord());
    }

    private IEnumerator CreatePersonalWord()
    {
        loadingManagement.EnableLoadingPanel();
        Texture2D texture = displaySelectedImage.sprite.texture;

        WordDTO newWord = new WordDTO
        {
            EnglishText = englishText.text,
            VietnameseText = vietnameseText.text,
            UserId = DBManager.User.UserId,
            WordCategoryId = 1,
            Image = texture.EncodeToPNG()
        };

        string jsonData = JsonConvert.SerializeObject(newWord);
        UnityWebRequest request = new UnityWebRequest(AddressAPI.WORD_URL, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();


        if (request.result == UnityWebRequest.Result.Success)
        {
            string toastStr = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? "Create Word Successfully" : "Tạo Từ Thành Công!";
            Toast.Show(toastStr, ToastColor.Green, ToastPosition.BottomCenter);
            StartCoroutine(Initialize());
            createPersonalPanel.gameObject.SetActive(false);
            ClearFields();
        }
        else
        {
            Debug.LogError("Failed to create personal word: " + request.error);
            string toastStr = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? "Create Word Fail" : "Tạo Từ Thất Bại!";
            Toast.Show(toastStr, ToastColor.Red, ToastPosition.BottomCenter);
        }
        loadingManagement.DisableLoadingPanel();

    }
    private void ClearFields()
    {
        englishText.text = string.Empty;
        vietnameseText.text = string.Empty;
        displaySelectedImage.sprite = null;
    }
}

