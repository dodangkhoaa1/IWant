using EasyUI.Toast;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManagement : MonoBehaviour
{

    [Header("Setting")]
    public Transform settingsPanel;
    [SerializeField] private Transform soundLanguageSetting;
    [SerializeField] private Transform soundSetting;
    [SerializeField] private Transform languageSetting;

    private string toastString;
    [HideInInspector]
    public Stack<Transform> panelStack = new Stack<Transform>();
    // Allow to turn off all setting panels
    public void TurnOffAll()
    {
        settingsPanel.gameObject.SetActive(false);
        languageSetting.gameObject.SetActive(false);
        soundSetting.gameObject.SetActive(false);
        soundLanguageSetting.gameObject.SetActive(false);
    }

    // Allow to open the sound and language setting panel
    public void OpenSoundLanguageSetting()
    {
        TurnOffAll();
        panelStack.Push(soundLanguageSetting);

        settingsPanel.gameObject.SetActive(true);
        soundLanguageSetting.gameObject.SetActive(true);
    }

    // Allow to open the sound setting panel
    public void OpenAdjustSound()
    {
        if (soundLanguageSetting.gameObject.activeSelf)
        {
            soundLanguageSetting.gameObject.SetActive(false);
        }
        panelStack.Push(soundSetting);

        soundSetting.gameObject.SetActive(true);
    }

    // Allow to open the language setting panel
    public void OpenSelectLanguage()
    {
        if (soundLanguageSetting.gameObject.activeSelf)
        {
            soundLanguageSetting.gameObject.SetActive(false);
        }
        panelStack.Push(languageSetting);

        languageSetting.gameObject.SetActive(true);
    }

    // Allow to close the currently open panel
    public void Close()
    {
        Transform lastPanel = panelStack.Pop();
        lastPanel.gameObject.SetActive(false);
        if (panelStack.Count == 0)
        {
            settingsPanel.gameObject.SetActive(false);
        }
        else if (panelStack.Peek() == soundLanguageSetting)
        {
            soundLanguageSetting.gameObject.SetActive(true);
        }
    }


    public void SignOut()
    {
        // Clear user data from DBManager
        DBManager.USER_DATA = null;
        DBManager.lastname = string.Empty;
        DBManager.gender = Gender.Female;

        PlayerPrefs.DeleteAll();

        // Show sign out success message
        toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE
            ? "Sign Out Successfully!"
            : "Đăng Xuất Thành Công!";
        Toast.Show(toastString, 1.5f, ToastColor.Green, ToastPosition.BottomCenter);

        // Load the sign-in scene
        SceneManager.LoadScene(SceneName.SignInScene.ToString());
    }
}
