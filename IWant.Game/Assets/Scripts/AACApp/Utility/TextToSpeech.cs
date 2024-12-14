using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using Assets.Scripts.Utility.Const;  // For scene management

public class TextToSpeech : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private AudioSource audioSource;
    [SerializeField] private SceneName sceneName;


    private void Start()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }
    

    public void OnButtonPress()
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

    private IEnumerator SendTextToSpeechRequest(string text, string filePath)
    {
        UnityWebRequest request = CreateTTSRequest(text);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Error: {request.error}");
        }
        else
        {
            string audioUrl = ExtractAudioUrl(request.downloadHandler.text);
            if (!string.IsNullOrEmpty(audioUrl))
            {
                yield return StartCoroutine(DownloadAndSaveAudio(audioUrl, filePath));
                yield return StartCoroutine(PlayAudioAndWaitThenContinue(filePath)); // Wait until audio finishes
            }
            else
            {
                Debug.LogError("Audio URL is missing or could not be parsed.");
            }
        }
    }

    private UnityWebRequest CreateTTSRequest(string text)
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

        UnityWebRequest request = new UnityWebRequest(AddressAPI.TEXT_TO_SPEECH_URL, "POST");
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonData));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("accept", "application/json");
        request.SetRequestHeader("authorization", $"Bearer {AddressAPI.TEXT_TO_SPEECH_API_KEY}");

        return request;
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
        using (UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip(audioUrl, AudioType.WAV))
        {
            yield return audioRequest.SendWebRequest();

            if (audioRequest.result == UnityWebRequest.Result.ConnectionError || audioRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Audio Download Error: {audioRequest.error}");
            }
            else
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(audioRequest);
                if (clip != null)
                {
                    Debug.Log("Audio downloaded successfully. Saving to file...");
                    File.WriteAllBytes(filePath, audioRequest.downloadHandler.data);
                    PlayAudioClip(clip);
                }
                else
                {
                    Debug.LogError("Failed to load audio clip.");
                }
            }
        }
    }

    private void PlayAudioClip(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
            Debug.Log("Audio is now playing!");
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

        // Wait until the audio finishes playing
        while (audioSource.isPlaying)
        {
            yield return null; // Wait for the next frame
        }

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
                PlayAudioClip(DownloadHandlerAudioClip.GetContent(audioRequest));
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
