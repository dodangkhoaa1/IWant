using System.Collections;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Globalization;
using EasyUI.Toast;

public class TextToSpeech : MonoBehaviour
{
    [SerializeField] private SceneName sceneName;

    private TextMeshProUGUI textMeshProUGUI;
    private APIKeyLoader _APIKeyLoader;

    private void Start()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        _APIKeyLoader = gameObject.AddComponent<APIKeyLoader>();

    }

    private string GetStreamingAssetsPath(string fileName)
    {
        //return "file://" + Path.Combine(Application.streamingAssetsPath, fileName + ".wav");
#if UNITY_ANDROID
        return Path.Combine(Application.streamingAssetsPath, fileName + ".wav"); // Không cần file:// trên Android
#else
        return "file://" + Path.Combine(Application.streamingAssetsPath, fileName + ".wav");
#endif
    }

    private string GetPersistentDataPath(string fileName)
    {
        return Path.Combine(Application.persistentDataPath, fileName + ".wav");
    }

    // Allow to call text to speech functionality
    public void CallTextToSpeech()
    {
        StartCoroutine(CallTextToSpeechCoroutine());
    }

    // Allow to call text to speech functionality as a coroutine
    public IEnumerator CallTextToSpeechCoroutine()
    {
        string inputText = textMeshProUGUI.text;
        if (!string.IsNullOrEmpty(inputText))
        {
            string fileName = GetUniqueFileName(inputText, PrefsKey.GetVoiceByLanguageAndGender);
            string streamingFilePath = GetStreamingAssetsPath(fileName);
            string persistentFilePath = GetPersistentDataPath(fileName);

            bool fileExistsInStreamingAssets = false;

#if UNITY_ANDROID && !UNITY_EDITOR
        // Kiểm tra file trong StreamingAssets bằng UnityWebRequest
        using (UnityWebRequest request = UnityWebRequest.Head(streamingFilePath))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                fileExistsInStreamingAssets = true;
            }
        }
#else
            fileExistsInStreamingAssets = File.Exists(streamingFilePath);
#endif

            if (fileExistsInStreamingAssets)
            {
                Debug.Log($"✅ Playing from StreamingAssets: {streamingFilePath}");
                yield return StartCoroutine(PlayAudioAndWaitThenContinue(streamingFilePath));
            }
            // Khi xuất xóa cái này
            // else
            // {
            //     Debug.Log($"📥 File not found. Downloading and saving to: {streamingFilePath}");
            //     yield return StartCoroutine(SendTextToSpeechRequest(inputText, streamingFilePath));
            // }

            // Khi xuất thì mở cmt này 
            else if (File.Exists(persistentFilePath))
            {
                Debug.Log($"✅ Playing from PersistentDataPath: {persistentFilePath}");
                yield return StartCoroutine(PlayAudioAndWaitThenContinue(persistentFilePath));
            }
            else
            {
                Debug.Log($"📥 File not found. Downloading and saving to: {persistentFilePath}");
                yield return StartCoroutine(SendTextToSpeechRequest(inputText, persistentFilePath));
            }
        }
        else
        {
            Debug.LogWarning("Input text is empty.");
        }
    }

    // Allow to send text to speech request
    private IEnumerator SendTextToSpeechRequest(string text, string filePath)
    {
        string jsonData = $@"
        {{
            ""response_as_dict"": true,
            ""attributes_as_list"": false,
            ""show_base_64"": false,
            ""show_original_response"": false,
            ""rate"": -10, 
            ""pitch"": 15,
            ""volume"": 100,
            ""sampling_rate"": 0,
            ""providers"": [ ""{PrefsKey.GetVoiceByLanguageAndGender}"" ],
            ""language"": ""{PrefsKey.LANGUAGE}"",
            ""text"": ""{text}"",
            ""audio_format"": ""wav""
        }}";

        yield return ApiService.Instance.PostCoroutine(
            AddressAPI.TEXT_TO_SPEECH_URL,
            jsonData,
            _APIKeyLoader.GetApiKey(),
            (response) =>
            {
                string audioUrl = ExtractAudioUrl(response);
                if (!string.IsNullOrEmpty(audioUrl))
                {
                    StartCoroutine(DownloadAndSaveAudio(audioUrl, filePath));
                }
                else
                {
                    Debug.LogError("Audio URL is missing or could not be parsed.");
                }
            },
            (error) =>
            {
                Debug.LogError($"Error: {error}");
            }
        );
    }

    // Allow to extract audio URL from JSON response
    private string ExtractAudioUrl(string jsonResponse)
    {
        const string key = "\"audio_resource_url\":\"";
        int startIndex = jsonResponse.IndexOf(key) + key.Length;

        if (startIndex >= key.Length)
        {
            int endIndex = jsonResponse.IndexOf("\"", startIndex);
            if (endIndex > startIndex)
            {
                return jsonResponse.Substring(startIndex, endIndex - startIndex);
            }
        }

        return null;
    }

    // Allow to download and save audio
    private IEnumerator DownloadAndSaveAudio(string audioUrl, string filePath)
    {
        yield return ApiService.Instance.GetAudioClip(audioUrl,
            (clip, audioRequest) =>
            {
                if (clip != null)
                {
                    Debug.Log("Audio downloaded successfully. Saving to file...");
                    File.WriteAllBytes(filePath, audioRequest.downloadHandler.data);

                    //mở cmt khi muốn export
                    StartCoroutine(PlayAudioAndWaitThenContinue(filePath));
                }
            },
            (error) =>
            {
                Debug.LogError($"Audio Download Error: {error}");
            }
        );
    }

    // Allow to play audio clip
    private IEnumerator PlayAudioClip(AudioClip clip)
    {
        if (clip != null)
        {
            AudioManagement.instance.PlaySFX(clip);
            Debug.Log("Audio is now playing!");
            yield return new WaitForSecondsRealtime(clip.length - 0.75f); // Use WaitForSecondsRealtime to avoid delays

        }
        else
        {
            Debug.LogError("Failed to load audio clip.");
        }
    }

    // Allow to get unique file name
    private string GetUniqueFileName(string text, string gender)
    {
        string sanitizedText = RemoveVietnameseAccents(text);
        string textHash = GetHash(text);
        string fileName = $"{gender}_{sanitizedText}_{textHash.Substring(0, 8)}";

        foreach (char c in Path.GetInvalidFileNameChars())
        {
            fileName = fileName.Replace(c, '_');
        }

        return fileName;
    }

    // Allow to remove Vietnamese accents from text
    private string RemoveVietnameseAccents(string input)
    {
        string normalized = input.Normalize(NormalizationForm.FormD);
        char[] chars = normalized
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            .ToArray();
        string cleaned = new string(chars).Normalize(NormalizationForm.FormC);

        cleaned = Regex.Replace(cleaned, @"[^a-zA-Z0-9\s]", "");
        cleaned = cleaned.Replace(" ", "_");
        return cleaned;
    }

    // Allow to get hash of a string
    private string GetHash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    // Allow to play the audio and wait until it finishes before continuing
    private IEnumerator PlayAudioAndWaitThenContinue(string filePath)
    {
        yield return StartCoroutine(PlayAudioFromFile(filePath));
        TransitionToNextScene();
    }

    // Allow to play audio from file
    private IEnumerator PlayAudioFromFile(string filePath)
    {
        using (UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip($"{filePath}", AudioType.WAV))
        {
            yield return audioRequest.SendWebRequest();

            if (audioRequest.result == UnityWebRequest.Result.ConnectionError || audioRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error loading local audio file: {audioRequest.error}");
            }
            else
            {
                yield return PlayAudioClip(DownloadHandlerAudioClip.GetContent(audioRequest));
            }
        }
    }

    // Allow to transition to the next scene
    private void TransitionToNextScene()
    {
        if (sceneName != SceneName.Null)
            SceneManager.LoadScene(sceneName.ToString()); // Replace with the scene you want to load
    }

    //// New method to download all audio for words and categories
    //public IEnumerator DownloadAllAudio(List<WordDTO> words, List<WordCategoryDTO> categories)
    //{

    //    foreach (var word in words)
    //    {
    //        yield return StartCoroutine(DownloadAudioForWord(word.EnglishText, PrefsKey.ENGLISH_CODE, AddressAPI.MALE_EN_US));
    //        yield return StartCoroutine(DownloadAudioForWord(word.EnglishText, PrefsKey.ENGLISH_CODE, AddressAPI.FEMALE_EN_US));
    //        yield return StartCoroutine(DownloadAudioForWord(word.VietnameseText, PrefsKey.VIETNAM_CODE, AddressAPI.MALE_VI_VN));
    //        yield return StartCoroutine(DownloadAudioForWord(word.VietnameseText, PrefsKey.VIETNAM_CODE, AddressAPI.FEMALE_VI_VN));
    //    }

    //    foreach (var category in categories)
    //    {
    //        yield return StartCoroutine(DownloadAudioForWord(category.EnglishName, PrefsKey.ENGLISH_CODE, AddressAPI.MALE_EN_US));
    //        yield return StartCoroutine(DownloadAudioForWord(category.EnglishName, PrefsKey.ENGLISH_CODE, AddressAPI.FEMALE_EN_US));
    //        yield return StartCoroutine(DownloadAudioForWord(category.VietnameseName, PrefsKey.VIETNAM_CODE, AddressAPI.MALE_VI_VN));
    //        yield return StartCoroutine(DownloadAudioForWord(category.VietnameseName, PrefsKey.VIETNAM_CODE, AddressAPI.FEMALE_VI_VN));
    //    }
    //}

    //private IEnumerator DownloadAudioForWord(string text, string language, string gender)
    //{
    //    string fileName = GetUniqueFileName(text, gender);
    //    //string filePath = Path.Combine(Application.persistentDataPath, fileName + ".wav");
    //    string filePath = GetStreamingAssetsPath(fileName);

    //    if (!File.Exists(filePath))
    //    {
    //        string jsonData = $@"
    //        {{
    //            ""response_as_dict"": true,
    //            ""attributes_as_list"": false,
    //            ""show_base_64"": false,
    //            ""show_original_response"": false,
    //            ""rate"": -10, 
    //            ""pitch"": 15,
    //            ""volume"": 100,
    //            ""sampling_rate"": 0,
    //            ""providers"": [ ""{gender}"" ],
    //            ""language"": ""{language}"",
    //            ""text"": ""{text}"",
    //            ""audio_format"": ""wav""
    //        }}";

    //        yield return ApiService.Instance.PostCoroutine(
    //            AddressAPI.TEXT_TO_SPEECH_URL,
    //            jsonData,
    //            _APIKeyLoader.GetApiKey(),
    //            (response) =>
    //            {
    //                string audioUrl = ExtractAudioUrl(response);
    //                if (!string.IsNullOrEmpty(audioUrl))
    //                {
    //                    StartCoroutine(DownloadAndSaveAudio(audioUrl, filePath));
    //                }
    //                else
    //                {
    //                    Debug.LogError("Audio URL is missing or could not be parsed.");
    //                }
    //            },
    //            (error) =>
    //            {
    //                Debug.LogError($"Error: {error}");
    //            }
    //        );
    //    }else{
    //        Debug.Log("File Exist!");
    //    }
    //}
}