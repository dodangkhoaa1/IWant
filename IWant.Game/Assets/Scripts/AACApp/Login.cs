using Assets.Scripts.Utility.Const;
using EasyUI.Toast;
using Newtonsoft.Json;
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
    private string toastString;

    public void CallLogin()
    {
        StartCoroutine(LoginMethod());
    }

    IEnumerator LoginMethod()
    {
        if (string.IsNullOrEmpty(usernameField.text) || string.IsNullOrEmpty(passwordField.text))
        {
            Debug.LogWarning("FullName or Password field is empty.");
            toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? "Please fill in both FullName and password." : "Vui lòng điền cả Tên đăng nhập và Mật khẩu";
            Toast.Show(toastString, 1.5f, ToastColor.Red, ToastPosition.BottomCenter);
            yield break;
        }

        // Prepare JSON payload
        LoginRequestDto data = new LoginRequestDto
        {
            UserName = usernameField.text,
            PasswordHash = passwordField.text
        };

        string jsonData = JsonUtility.ToJson(data);
        Debug.Log("Sending JSON: " + jsonData);

        // Use ApiService to send the POST request
        string url = $"{AddressAPI.USER_URL}/login";

        yield return ApiService.Instance.PostCoroutine(
            url,
            jsonData,
            null, // No authorization token required for login
            onSuccess: responseText =>
            {
                try
                {
                    UserResponse response =  JsonConvert.DeserializeObject<UserResponse>(responseText);

                    if (response != null && !string.IsNullOrEmpty(response.FullName))
                    {
                        DBManager.fullName = response.FullName;
                        toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? $"User login successful. Welcome, {response.FullName}!" : $"Đăng nhập thành công. Chào mừng, {response.FullName}!";
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

    public void VerifyInputs()
    {
        submitButton.interactable = (usernameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
