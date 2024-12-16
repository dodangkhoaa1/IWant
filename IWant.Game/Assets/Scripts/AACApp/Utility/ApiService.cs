using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
#nullable enable

public class ApiService : MonoBehaviour
{
    private static ApiService _instance;

    // Singleton instance to ensure only one instance of the service exists
    public static ApiService Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("ApiService");
                _instance = obj.AddComponent<ApiService>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    /// <summary>
    /// Makes a POST request to the given URL with the specified JSON payload.
    /// </summary>
    /// <param name="url">The API endpoint URL.</param>
    /// <param name="jsonPayload">The JSON payload as a string.</param>
    /// <param name="onSuccess">Callback executed on success with the response text.</param>
    /// <param name="onError">Callback executed on failure with the error message.</param>

    public IEnumerator PostCoroutine(string url, string jsonPayload, string? authorizationToken, Action<string> onSuccess, Action<string> onError)
    {
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("accept", "application/json");
        if (!string.IsNullOrEmpty(authorizationToken))
        {
            request.SetRequestHeader("authorization", $"Bearer {authorizationToken}");
        }

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"POST Success: {request.downloadHandler.text}");
            onSuccess?.Invoke(request.downloadHandler.text);
        }
        else
        {
            Debug.LogError($"POST Error: {request.error}");
            onError?.Invoke(request.error);
        }
    }

    /// <summary>
    /// Makes a GET request to the given URL.
    /// </summary>
    /// <param name="url">The API endpoint URL.</param>
    /// <param name="onSuccess">Callback executed on success with the response text.</param>
    /// <param name="onError">Callback executed on failure with the error message.</param>

    public IEnumerator GetCoroutine(string url, Action<string> onSuccess, Action<string> onError)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("accept", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"GET Success: {request.downloadHandler.text}");
            onSuccess?.Invoke(request.downloadHandler.text);
        }
        else
        {
            Debug.LogError($"GET Error: {request.error}");
            onError?.Invoke(request.error);
        }
    }

    public IEnumerator GetAudioClip(string url, Action<AudioClip, UnityWebRequest> onSuccess, Action<string> onError)
    {
        using (UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV))
        {
            yield return audioRequest.SendWebRequest();

            if (audioRequest.result == UnityWebRequest.Result.Success)
            {
                onSuccess?.Invoke(DownloadHandlerAudioClip.GetContent(audioRequest), audioRequest);
            }
            else
            {
                onError?.Invoke(audioRequest.error);
            }
        }
    }

    /// <summary>
    /// Makes a DELETE request to the given URL.
    /// </summary>
    /// <param name="url">The API endpoint URL.</param>
    /// <param name="onSuccess">Callback executed on success with the response text.</param>
    /// <param name="onError">Callback executed on failure with the error message.</param>

    public IEnumerator DeleteCoroutine(string url, Action<string> onSuccess, Action<string> onError)
    {
        UnityWebRequest request = UnityWebRequest.Delete(url);
        request.SetRequestHeader("accept", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"DELETE Success: {request.downloadHandler.text}");
            onSuccess?.Invoke(request.downloadHandler.text);
        }
        else
        {
            Debug.LogError($"DELETE Error: {request.error}");
            onError?.Invoke(request.error);
        }
    }

    /// <summary>
    /// Makes a PUT request to the given URL with the specified JSON payload.
    /// </summary>
    /// <param name="url">The API endpoint URL.</param>
    /// <param name="jsonPayload">The JSON payload as a string.</param>
    /// <param name="onSuccess">Callback executed on success with the response text.</param>
    /// <param name="onError">Callback executed on failure with the error message.</param>

    public IEnumerator PutCoroutine(string url, string jsonPayload, Action<string> onSuccess, Action<string> onError)
    {
        UnityWebRequest request = new UnityWebRequest(url, "PUT");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"PUT Success: {request.downloadHandler.text}");
            onSuccess?.Invoke(request.downloadHandler.text);
        }
        else
        {
            Debug.LogError($"PUT Error: {request.error}");
            onError?.Invoke(request.error);
        }
    }
}
