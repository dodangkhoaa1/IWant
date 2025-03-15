using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Allow to call text to speech functionality
    public void CallTextToSpeech()
    {
        string inputText = textMeshProUGUI.text;
        if (!string.IsNullOrEmpty(inputText))
        {
            string fileName = GetUniqueFileName(inputText, PrefsKey.GetVoiceByLanguageAndGender);
            string filePath = Path.Combine(Application.persistentDataPath, fileName + ".wav");

            if (File.Exists(filePath))
            {
                Debug.Log($"File exists: {filePath}. Playing from local storage.");
                StartCoroutine(PlayAudioAndWaitThenContinue(filePath));
            }
            else
            {
                Debug.Log($"File not found. Downloading and saving: {filePath}");

                StartCoroutine(SendTextToSpeechRequest(inputText, filePath));
            }
        }
        else
        {
            Debug.LogWarning("Input text is empty.");
        }
    }

    // Allow to call text to speech functionality as a coroutine
    public IEnumerator CallTextToSpeechCoroutine()
    {
        string inputText = textMeshProUGUI.text;
        if (!string.IsNullOrEmpty(inputText))
        {
            string fileName = GetUniqueFileName(inputText, PrefsKey.GetVoiceByLanguageAndGender);
            string filePath = Path.Combine(Application.persistentDataPath, fileName + ".wav");

            if (File.Exists(filePath))
            {
                Debug.Log($"File exists: {filePath}. Playing from local storage.");
                yield return StartCoroutine(PlayAudioAndWaitThenContinue(filePath));
            }
            else
            {
                Debug.Log($"File not found. Downloading and saving: {filePath}");

                yield return StartCoroutine(SendTextToSpeechRequest(inputText, filePath));
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
            AddressAPI.TEXT_TO_SPEECH_API_KEY,
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
            //yield return new WaitForSeconds(clip.length);
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
        // Play the audio from the file
        yield return StartCoroutine(PlayAudioFromFile(filePath));

        // Continue with the next action (e.g., changing scene, etc.)
        Debug.Log("Audio finished playing. Continuing with next action...");
        // Call the method to transition scene or perform another action
        TransitionToNextScene();
    }

    // Allow to play audio from file
    private IEnumerator PlayAudioFromFile(string filePath)
    {
        using (UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip($"file://{filePath}", AudioType.WAV))
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

    // New method to download all audio for words and categories
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
    //    string filePath = Path.Combine(Application.persistentDataPath, fileName + ".wav");

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
    //            AddressAPI.TEXT_TO_SPEECH_API_KEY,
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
    //    }
    //}
}
