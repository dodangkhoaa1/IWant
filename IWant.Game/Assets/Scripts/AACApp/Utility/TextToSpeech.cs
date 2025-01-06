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

public class TextToSpeech : MonoBehaviour
{
    [SerializeField] private SceneName sceneName;
   
    private TextMeshProUGUI textMeshProUGUI;
    private AudioSource audioSource;

    private void Start()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        audioSource = AudioManager.Instance.GetComponent<AudioSource>();
    }

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
            ""volume"": 0,
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

    private IEnumerator PlayAudioClip(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
            Debug.Log("Audio is now playing!");
            yield return new WaitForSeconds(clip.length);
        }
        else
        {
            Debug.LogError("Failed to load audio clip.");
        }
    }

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

    // Coroutine to play the audio and wait until it finishes before continuing
    private IEnumerator PlayAudioAndWaitThenContinue(string filePath)
    {
        // Play the audio from the file
        yield return StartCoroutine(PlayAudioFromFile(filePath));

        // Continue with the next action (e.g., changing scene, etc.)
        Debug.Log("Audio finished playing. Continuing with next action...");
        // Call the method to transition scene or perform another action
        TransitionToNextScene();
    }

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

    // Transition to the next scene (you can replace it with your own scene change logic)
    private void TransitionToNextScene()
    {
        if (sceneName != SceneName.Null)
            SceneManager.LoadScene(sceneName.ToString()); // Replace with the scene you want to load
    }
}
