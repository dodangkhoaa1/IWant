using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColoringGuideManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button closeButton;

    [Header("Guideline Pictures")]
    [SerializeField] private Sprite[] englishSprites;
    [SerializeField] private Sprite[] vietnameseSprites;

    [Header("Display")]
    [SerializeField] private GameObject darkPanel;
    [SerializeField] private Image displayImage;
    [SerializeField] private TextMeshProUGUI pagenumber;

    [Header("Mascot")]
    [SerializeField] private Animator mascotAnimator;

    private int currentIndex = 0;
    private Sprite[] currentSprites;

    private string animationParam = "isVertical";

    private void Start()
    {
        // Assuming English is the default language
        SetLanguage();

        // Add onClick listeners to buttons
        previousButton.onClick.AddListener(OnPreviousButtonClicked);
        nextButton.onClick.AddListener(OnNextButtonClicked);
        closeButton.onClick.AddListener(OnClickCloseClicked);
    }

    public void SetLanguage()
    {
        currentSprites = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? englishSprites : vietnameseSprites;
        currentIndex = 0;
        UpdateGuide();
    }

    public void OnNextButtonClicked()
    {
        if (currentIndex < currentSprites.Length - 1)
        {
            currentIndex++;
            UpdateGuide();
        }
    }

    public void OnPreviousButtonClicked()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateGuide();
        }
    }

    private void UpdateGuide()
    {
        displayImage.sprite = currentSprites[currentIndex];
        pagenumber.text = $"{currentIndex + 1}/{currentSprites.Length}";
        previousButton.gameObject.SetActive(currentIndex > 0);
        nextButton.gameObject.SetActive(currentIndex < currentSprites.Length - 1);

        bool isVertical = currentIndex < 3; // từ hình 4 trở lên là hình nằm ngang
        mascotAnimator.SetBool(animationParam, isVertical);
    }
    public void OnClickCloseClicked()
    {
        currentIndex = 0;
        darkPanel.SetActive(false);
        UpdateGuide();
    }


}
