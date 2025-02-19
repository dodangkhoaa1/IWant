using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManagement : MonoBehaviour
{
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

    [Header("Close Button")]
    [SerializeField] private Sprite closeSprite;
    [SerializeField] private Sprite leftArrowSprite;
    [SerializeField] private Image closeButton;

    Stack<Transform> panelStack = new Stack<Transform>();

    private int currentImageIndex;

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
        UpdateCloseBtnUI();
    }

    // Allow to open the sound and language setting panel
    public void OpenSoundLanguageSetting()
    {
        TurnOffAll();
        panelStack.Push(soundLanguageSetting);

        darkPanel.gameObject.SetActive(true);
        soundLanguageSetting.gameObject.SetActive(true);
        UpdateCloseBtnUI();
    }

    // Allow to open the sound setting panel
    public void OpenAdjustSound()
    {
        panelStack.Push(soundSetting);

        soundSetting.gameObject.SetActive(true);
        UpdateCloseBtnUI();
    }

    // Allow to open the language setting panel
    public void OpenSelectLanguage()
    {
        panelStack.Push(languageSetting);

        languageSetting.gameObject.SetActive(true);
        UpdateCloseBtnUI();
    }

    // Allow to close the currently open panel
    public void Close()
    {
        Transform lastPanel = panelStack.Pop();
        lastPanel.gameObject.SetActive(false);
        if (panelStack.Count == 0) darkPanel.gameObject.SetActive(false);
        UpdateCloseBtnUI();
    }

    // Allow to update the close button UI based on the panel stack count
    private void UpdateCloseBtnUI()
    {
        closeButton.sprite = panelStack.Count > 1 ? leftArrowSprite : closeSprite;
    }
}
