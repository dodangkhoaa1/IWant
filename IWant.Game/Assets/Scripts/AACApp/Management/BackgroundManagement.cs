using EasyUI.Toast;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundManagement : MonoBehaviour
{
    [Header("Macos")]
    [SerializeField] private Transform macosPosition;
    [SerializeField] private Transform[] positions;


    [Header("Adjust background")]
    [SerializeField] private Sprite[] backgroundImages;
    [SerializeField] private Image backgroundCanvas;
    [SerializeField] private Image displayBackground;
    [SerializeField] private Transform adjustBackground;

    [Header("Setting")]
    [SerializeField] private Transform darkPanel;
    [SerializeField] private Transform soundLanguageSetting;
    [SerializeField] private Transform soundSetting;
    [SerializeField] private Transform languageSetting;


    Stack<Transform> panelStack = new Stack<Transform>();

    private int currentImageIndex;
    private string toastString;

    private void Awake()
    {
        // Set the screen orientation to portrait mode
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the current image index and set the initial background images
        currentImageIndex = 0;
        backgroundCanvas.sprite = backgroundImages[currentImageIndex];
        displayBackground.sprite = backgroundImages[currentImageIndex];
        macosPosition.position = positions[currentImageIndex].position;
    }

    // Allow to switch to the next background image
    public void NextBackground()
    {
        currentImageIndex++;
        // Validate index
        if (currentImageIndex > backgroundImages.Length - 1) currentImageIndex = 0;

        displayBackground.sprite = backgroundImages[currentImageIndex];
    }

    // Allow to switch to the previous background image
    public void PreviousBackground()
    {
        currentImageIndex--;
        // Validate index
        if (currentImageIndex < 0) currentImageIndex = backgroundImages.Length - 1;

        displayBackground.sprite = backgroundImages[currentImageIndex];
    }

    // Allow to select the current background image
    public void SelectBackground()
    {
        backgroundCanvas.sprite = backgroundImages[currentImageIndex];
        macosPosition.position = positions[currentImageIndex].position;
    }

    // Allow to turn off all setting panels
    private void TurnOffAll()
    {
        darkPanel.gameObject.SetActive(false);
        languageSetting.gameObject.SetActive(false);
        soundSetting.gameObject.SetActive(false);
        soundLanguageSetting.gameObject.SetActive(false);
    }

    // Allow to open the adjust background panel
    public void OpenAdjustBackground()
    {
        TurnOffAll();
        panelStack.Push(adjustBackground);

        darkPanel.gameObject.SetActive(true);
        adjustBackground.gameObject.SetActive(true);
    }

    // Allow to open the sound and language setting panel
    public void OpenSoundLanguageSetting()
    {
        TurnOffAll();
        panelStack.Push(soundLanguageSetting);

        darkPanel.gameObject.SetActive(true);
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
            darkPanel.gameObject.SetActive(false);
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
        DBManager.fullName = string.Empty;
        DBManager.gender = Gender.Female;

        PlayerPrefs.DeleteAll();

        // Show sign out success message
        toastString = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE
            ? "You have been signed out successfully."
            : "Bạn đã đăng xuất thành công.";
        Toast.Show(toastString, 1.5f, ToastColor.Green, ToastPosition.BottomCenter);

        // Load the sign-in scene
        SceneManager.LoadScene(SceneName.SignInScene.ToString());
    }
}
