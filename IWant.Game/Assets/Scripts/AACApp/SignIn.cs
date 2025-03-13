using EasyUI.Toast;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignIn : MonoBehaviour
{
    [SerializeField] private SceneName sceneToLoad = SceneName.MainMenu;
    [SerializeField] private TMP_InputField usernameField;
    [SerializeField] private TMP_InputField passwordField;

    public Button submitButton;
    private string toastString;

    // Allow to set the screen orientation to portrait mode
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Allow to initiate the sign-in process
    public void CallSignIn()
    {
        StartCoroutine(SignInMethod());
    }

    // Allow to handle the sign-in process asynchronously
    IEnumerator SignInMethod()
    {
        if (string.IsNullOrEmpty(usernameField.text) || string.IsNullOrEmpty(passwordField.text))
        {
            Debug.LogWarning("FullName or Password field is empty.");
            toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? "Please fill in both FullName and password." : "Vui lòng điền cả Tên đăng nhập và Mật khẩu";
            Toast.Show(toastString, 1.5f, ToastColor.Red, ToastPosition.BottomCenter);
            yield break;
        }

        // Prepare JSON payload
        SignInRequestDto data = new SignInRequestDto
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
                    UserResponseDTO response = JsonConvert.DeserializeObject<UserResponseDTO>(responseText);

                    if (response != null && !string.IsNullOrEmpty(response.FullName))
                    {
                        if (response.Status == true)
                        {
                            //DBManager.USER_DATA = (UserResponseDTO)response;
                            // Chuyển đổi response thành JSON và lưu vào PlayerPrefs
                            string userJson = JsonConvert.SerializeObject(response);
                            DBManager.USER_DATA = userJson;

                            Debug.Log("User data saved to PlayerPrefs: " + userJson);

                            // Xử lý đăng nhập thành công
                            string[] wordInName = response.FullName.Trim().Split(" ");
                            string lastName = wordInName[wordInName.Length - 1];
                            DBManager.fullName = lastName;
                            DBManager.gender = response.Gender == true ? Gender.Male : Gender.Female;

                            Debug.Log($"The gender of {DBManager.fullName} is {DBManager.gender.ToString()}");
                            toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE
                                ? $"User login successful. Welcome, {response.FullName}!"
                                : $"Đăng nhập thành công. Chào mừng, {response.FullName}!";

                            Toast.Show(toastString, 1.5f, ToastColor.Green, ToastPosition.BottomCenter);
                            SceneManager.LoadScene(sceneToLoad.ToString());
                        }
                        else
                        {
                            toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE
                                ? $"Sign in fail! The user {response.FullName} was not available!"
                                : $"Đăng nhập thất bại! Tài khoản {response.FullName} đã hết hạn! Vui lòng thử lại với tài khoản khác!";

                            Toast.Show(toastString, 1.5f, ToastColor.Red, ToastPosition.BottomCenter);
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Unexpected response format. Response: " + responseText);
                        toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE
                            ? "Invalid response from server. Please try again."
                            : "Phản hồi từ máy chủ không hợp lệ. Vui lòng thử lại.";

                        Toast.Show(toastString, 1.5f, ToastColor.Red, ToastPosition.BottomCenter);
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Failed to parse server response: {ex.Message}\nResponse: {responseText}");
                    toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE
                        ? "An error occurred while processing the server response."
                        : "Xảy ra lỗi trong quá trình phản hồi từ máy chủ. Vui lòng thử lại.";

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

    // Allow to verify the input fields and enable/disable the submit button
    public void VerifyInputs()
    {
        submitButton.interactable = (usernameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
    private void Start()
    {
        if (!string.IsNullOrEmpty(DBManager.USER_DATA))
        {
            SceneManager.LoadScene(sceneToLoad.ToString());
        }
    }
    public void QuitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
    

    
}
