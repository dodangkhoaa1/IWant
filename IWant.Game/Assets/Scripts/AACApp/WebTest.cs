using Assets.Scripts.AACApp.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class WebTest : MonoBehaviour
{
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
            Player[] users = JsonHelper.FromJson<Player>(responseText);
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
