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

    [Header("Settings Manager")]
    [SerializeField] private SettingsManagement settingsManagement;


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

    // Allow to open the adjust background panel
    public void OpenAdjustBackground()
    {
        settingsManagement.TurnOffAll();
        settingsManagement.panelStack.Push(adjustBackground);

        settingsManagement.settingsPanel.gameObject.SetActive(true);
        adjustBackground.gameObject.SetActive(true);
    }
}
