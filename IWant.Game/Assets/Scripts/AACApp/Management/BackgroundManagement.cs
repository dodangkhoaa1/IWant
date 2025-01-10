using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManagement : MonoBehaviour
{
    [SerializeField] private Sprite[] backgroundImages;
    [SerializeField] private Image backgroundCanvas;
    [SerializeField] private Image displayBackground;

    [SerializeField] private Transform darkPanel;
    [SerializeField] private Transform changeBackgroundPanel;
    [SerializeField] private Transform changeSoundPanel;

    private int currentImageIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentImageIndex = 0;
        backgroundCanvas.sprite = backgroundImages[currentImageIndex];
        displayBackground.sprite = backgroundImages[currentImageIndex];
    }

    public void NextBackground()
    {
        currentImageIndex++;
        //Validate index
        if (currentImageIndex > backgroundImages.Length - 1) currentImageIndex = 0;

        displayBackground.sprite = backgroundImages[currentImageIndex];
    }

    public void PreviousBackground()
    {
        currentImageIndex--;
        //Validate index
        if (currentImageIndex < 0) currentImageIndex = backgroundImages.Length - 1;

        displayBackground.sprite = backgroundImages[currentImageIndex];
    }

    public void OpenBackgroundPanel()
    {
        darkPanel.gameObject.SetActive(true);
        changeBackgroundPanel.gameObject.SetActive(true);
    }
    public void CloseBackgroundPanel()
    {
        darkPanel.gameObject.SetActive(false);
        changeBackgroundPanel.gameObject.SetActive(false);
    }
    public void OpenSoundPanel()
    {
        darkPanel.gameObject.SetActive(true);
        changeSoundPanel.gameObject.SetActive(true);
    }
    public void CloseSoundPanel()
    {
        darkPanel.gameObject.SetActive(false);
        changeSoundPanel.gameObject.SetActive(false);
    }

    public void SelectBackground()
    {
        backgroundCanvas.sprite = backgroundImages[currentImageIndex];
    }
}
