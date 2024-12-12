using Assets.Scripts.Utility.Const;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        if (string.IsNullOrEmpty(usernameField.text) || string.IsNullOrEmpty(passwordField.text))
        {
            Debug.LogError("Username or Password field is empty.");
            yield break;
        }

        // Prepare JSON payload
        RegisterData data = new RegisterData
        {
            username = usernameField.text,
            password = passwordField.text
        };

        string jsonData = JsonUtility.ToJson(data);
        Debug.Log("Sending JSON: " + jsonData);

        // Create UnityWebRequest for POST
        UnityWebRequest playerRequest = new UnityWebRequest(AddressAPI.PLAYER_URL, "POST");
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
                    Debug.Log($"User created successfully. Username: {response.username}, ID: {response.id}");
                    SceneManager.LoadScene(SceneName.MainMenu.ToString());
                }
                else
                {
                    Debug.LogError("Unexpected response format. Response: " + responseText);
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Failed to parse server response: " + ex.Message + "\nResponse: " + responseText);
            }
        }
        else
        {
            Debug.LogError("Request error: " + playerRequest.error);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (usernameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
