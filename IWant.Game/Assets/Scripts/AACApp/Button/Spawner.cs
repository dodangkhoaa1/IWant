using Assets.Scripts.AACApp.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SpawnerButton : MonoBehaviour
{
    [SerializeField] GameObject containerButtons;
    [SerializeField] Button ttsButtonPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTTSButtons());

    }

    public IEnumerator SpawnTTSButtons()
    {

        UnityWebRequest request = new UnityWebRequest(AddressAPI.WORD_URL, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
/*
         if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);
            Word[] words = JsonHelper.FromJson<Word>(responseText);
            foreach (var word in words)
            {
                Button newTTSBtn = Instantiate(ttsButtonPrefab, containerButtons.transform, false);
                
                newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? word.VietnameseText : word.EnglishText;
            }

        }
        else
        {
            Debug.Log(request.responseCode);
        }
*/
        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);
            List<Word> words =JsonConvert.DeserializeObject<List<Word>>(responseText);
            foreach (var word in words)
            {
                Button newTTSBtn = Instantiate(ttsButtonPrefab, containerButtons.transform, false);

                newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.VIETNAM_CODE ? word.VietnameseText : word.EnglishText;
            }

        }
        else
        {
            Debug.Log(request.responseCode);
        }

    }
}
