using Assets.Scripts.Utility.Const;
using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public TextMeshProUGUI playerDisplay;
    public TextMeshProUGUI scoreDisplay;

    private void Awake()
    {
        if (DBManager.username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        playerDisplay.text = $"Player: {DBManager.username}";
        scoreDisplay.text = $"Score: {DBManager.score}";
    }
    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        SaveDataRequest saveRequest = new SaveDataRequest()
        {
            username = DBManager.username,
            score = DBManager.score
        };
        string jsonData = JsonUtility.ToJson(saveRequest);
        UnityWebRequest playerRequest = new UnityWebRequest(AddressAPI.PLAYER_URL+ "/savescore", "PUT");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        playerRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        playerRequest.downloadHandler = new DownloadHandlerBuffer();
        playerRequest.SetRequestHeader("Content-Type", "application/json");
        yield return playerRequest.SendWebRequest();

        if (playerRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Game Saved.");
        }
        else
        {
            Debug.LogError("Save failed. Error: #" + playerRequest.error);
        }
        //DBManager.LogOut();
        SceneManager.LoadScene(SceneName.MainMenu.ToString());

    }

    public void InscreaseScore(){
        DBManager.score++;
        scoreDisplay.text = $"Score: {DBManager.score}";
    }
}
