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

public class Registration : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;

    public Button submitButton;
    private string toastString;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        if (string.IsNullOrEmpty(usernameField.text) || string.IsNullOrEmpty(passwordField.text))
        {
            Debug.LogError("Username or Password field is empty.");
            toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? "Please fill in both username and password." : "Vui lòng điền cả Tên đăng nhập và Mật khẩu";
            Toast.Show(toastString, 1.5f, ToastColor.Red, ToastPosition.BottomCenter);
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
        // Use ApiService to send the POST request
        string url = $"{AddressAPI.PLAYER_URL}";
        yield return ApiService.Instance.PostCoroutine(
            url,
            jsonData,
            null, // No authorization token required for login
            onSuccess: responseText =>
            {
                try
                {
                    UserResponse response = JsonUtility.FromJson<UserResponse>(responseText);

                    if (response != null && !string.IsNullOrEmpty(response.username))
                    {
                        toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE 
                        ? $"User created successfully. Username: {response.username}"
                        : $"Người dùng đăng kí thành công. Tên đăng nhập: {response.username}";
                        Toast.Show(toastString, 1.5f, ToastColor.Green, ToastPosition.BottomCenter);
                        SceneManager.LoadScene(SceneName.MainMenu.ToString());
                    }
                    else
                    {
                        Debug.LogWarning("Unexpected response format. Response: " + responseText);
                        toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? "Invalid response from server. Please try again." : "Phản hồi từ máy chủ không hợp lệ. Vui lòng thử lại.";
                        Toast.Show(toastString, 1.5f, ToastColor.Red, ToastPosition.BottomCenter);
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Failed to parse server response: {ex.Message}\nResponse: {responseText}");
                    toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? "An error occurred while processing the server response." : "Xảy ra lỗi trong quá trình phản hồi từ máy chủ. Vui lòng thử lại.";
                    Toast.Show(toastString, 1.5f, ToastColor.Red, ToastPosition.BottomCenter);
                }
            },
            onError: error =>
            {
                Debug.LogWarning($"Login request error: {error}");
                toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? "Login failed. Please check your internet connection or try again later." : "Đăng nhập thất bại. Vui lòng kiểm tra kết nối mạng và thử lại.";
                Toast.Show(toastString, 1.5f, ToastColor.Red, ToastPosition.BottomCenter);
            }
        );
    }
    //Debug.Log();
    public void VerifyInputs()
    {
        submitButton.interactable = (usernameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
