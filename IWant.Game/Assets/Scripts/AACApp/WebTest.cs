using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class WebTest : MonoBehaviour
{
    [System.Serializable]
    public class User
    {
        public int id;
        public string username;
        public string password;
        public int score;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        UnityWebRequest request = new UnityWebRequest(AddressAPI.PLAYER_URL, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);
            User[] users = JsonHelper.FromJson<User>(responseText);
            foreach (var user in users)
            {
                Debug.Log($"Username: {user.username}, Score: {user.score}");
            }

        }
        else
        {
            Debug.Log(request.responseCode);
        }
    }

}
