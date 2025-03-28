using UnityEngine;
using UnityEngine.UI;

public class AboutUsManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button closeButton;

    [Header("Guideline Pictures")]
    [SerializeField] private Sprite[] englishSprites;
    //[SerializeField] private Sprite[] vietnameseSprites;

    [Header("Display")]
    [SerializeField] private GameObject darkPanel;
    [SerializeField] private Image displayImage;
    [SerializeField] private TMPro.TextMeshProUGUI pagenumber;

    [Header("Mascot")]
    [SerializeField] private Animator mascotAnimator;

    private string animationParam = "isVertical";

    private int currentIndex = 0;
    private Sprite[] currentSprites;


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
        //currentSprites = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? englishSprites : vietnameseSprites;
        currentSprites = englishSprites;
        currentIndex = 0;
        UpdateAboutUs();
    }

    public void OnNextButtonClicked()
    {
        if (currentIndex < currentSprites.Length - 1)
        {
            currentIndex++;
            UpdateAboutUs();
        }
    }

    public void OnPreviousButtonClicked()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateAboutUs();
        }
    }

    private void UpdateAboutUs()
    {
        bool isVertical = currentIndex <= 3;
        if (mascotAnimator != null)
        {
            mascotAnimator.SetBool(animationParam, isVertical);
        }

        displayImage.sprite = currentSprites[currentIndex];
        pagenumber.text = $"{currentIndex + 1}/{currentSprites.Length}";
        previousButton.gameObject.SetActive(currentIndex > 0);
        nextButton.gameObject.SetActive(currentIndex < currentSprites.Length - 1);


    }
    public void OnClickCloseClicked()
    {
        currentIndex = 0;
        darkPanel.SetActive(false);
        UpdateAboutUs();
    }
}
