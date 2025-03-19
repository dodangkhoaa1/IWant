using Newtonsoft.Json.Linq;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class APIKeyLoader : MonoBehaviour
{
    private string apiKey;

    private void Start()
    {
        StartCoroutine(GetApiKeyCoro(key => apiKey = key));
    }

    public IEnumerator GetApiKeyCoro(System.Action<string> callback)
    {
        string path;
#if UNITY_ANDROID && !UNITY_EDITOR
    path = Path.Combine(Application.streamingAssetsPath, "api_keys.json");
#else
        path = "file://" + Path.Combine(Application.streamingAssetsPath, "api_keys.json");
#endif

        using (UnityWebRequest www = UnityWebRequest.Get(path))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Unable to load api_keys.json: " + www.error);
                callback(null);
                yield break;
            }

            JObject apiKeys = JObject.Parse(www.downloadHandler.text);
            callback(apiKeys["TEXT_TO_SPEECH_API_KEY"]?.ToString());
        }
    }

    public string GetApiKey()
    {
        return apiKey;
    }


}
