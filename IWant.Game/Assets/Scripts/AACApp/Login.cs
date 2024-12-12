using Assets.Scripts.Utility.Const;
using EasyUI.Toast;
using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;

    public Button submitButton;

    
   
    public void CallLogin()
    {
        StartCoroutine(LoginMethod());
    }

    IEnumerator LoginMethod()
    {
        if (string.IsNullOrEmpty(usernameField.text) || string.IsNullOrEmpty(passwordField.text))
        {
            Debug.LogWarning("Username or Password field is empty.");
            yield break;
        }

        // Prepare JSON payload
        LoginData data = new LoginData
        {
            username = usernameField.text,
            password = passwordField.text
        };

        string jsonData = JsonUtility.ToJson(data);
        Debug.Log("Sending JSON: " + jsonData);

        // Create UnityWebRequest for POST
        UnityWebRequest playerRequest = new UnityWebRequest(AddressAPI.PLAYER_URL+"/login", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        playerRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        playerRequest.downloadHandler = new DownloadHandlerBuffer();
        playerRequest.SetRequestHeader("Content-Type", "application/json");

        yield return playerRequest.SendWebRequest();

        if (playerRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + playerRequest.downloadHandler.text);

            // Parse JSON response
            string responseText = playerRequest.downloadHandler.text;

            try
            {
                UserResponse response = JsonUtility.FromJson<UserResponse>(responseText);

                if (response != null && !string.IsNullOrEmpty(response.username))
                {
                    DBManager.username = response.username;
                    DBManager.score = response.score;
                    SceneManager.LoadScene(SceneName.MainMenu.ToString());
                    //Toast.Show($"User login successfully. Username: {response.username}", 1.5f, ToastColor.Green, ToastPosition.BottomCenter);
                }
                else
                {
                    Debug.LogWarning("Unexpected response format. Response: " + responseText);
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogWarning("Failed to parse server response: " + ex.Message + "\nResponse: " + responseText);
            }
        }
        else
        {
            Debug.LogWarning("Request error: " + playerRequest.error);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (usernameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
