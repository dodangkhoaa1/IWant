using System;
using UnityEngine;

public class LevelMapManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform mapContent;
    [SerializeField] private RectTransform[] levelButtonParents;
    [SerializeField] private LevelButton levelButtonPrefab;

    [Header(" Data ")]
    [SerializeField] private LevelDataSO[] levelDatas;

    [Header(" Actions ")]
    public static Action onLevelButtonClicked;

    private void Awake()
    {
        UIManager.onMapOpened += UpdateLevelButtonsInteractablity;
    }

    private void OnDestroy()
    {
        UIManager.onMapOpened -= UpdateLevelButtonsInteractablity;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
    }


    private void Initialize()
    {
        mapContent.anchoredPosition = Vector2.up * 1920 * (mapContent.childCount -1 );

        CreateLevelButtons();

        UpdateLevelButtonsInteractablity();
    }

    private void CreateLevelButtons()
    {
        for (int i = 0; i < levelDatas.Length; i++)
            CreateLevelButton(i, levelButtonParents[i]);
    }

    private void CreateLevelButton(int buttonIndex, Transform levelButtonParent)
    {
        LevelButton levelButton = Instantiate(levelButtonPrefab, levelButtonParent);

        int requiredScore = levelDatas[buttonIndex].GetRequiredHighscore();
        int bestScore = ScoreManager.instance.GetBestScore(); // Lấy điểm cao nhất của người chơi

        levelButton.Configure(buttonIndex + 1, requiredScore, bestScore);

        levelButton.GetButton().onClick.AddListener(() => LevelButtonClicked(buttonIndex));
    }   

    private void LevelButtonClicked(int buttonIndex)
    { 
        // Lưu level hiện tại vào GameManager
        GameManager.instance.SetCurrentLevel(levelDatas[buttonIndex]);

        while (transform.childCount > 0)
        {
            Transform t = transform.GetChild(0);
            t.SetParent(null);
            Destroy(t.gameObject);
        }

        Instantiate(levelDatas[buttonIndex].GetLevel(),transform);

        // Lấy UIManager và gọi hàm hiển thị điểm yêu cầu của level tiếp theo
        UIManager uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            int nextLevelIndex = buttonIndex + 1;
            int nextLevelRequiredScore = (nextLevelIndex < levelDatas.Length)
                ? levelDatas[nextLevelIndex].GetRequiredHighscore()
                : 0; // Nếu không có level tiếp theo, đặt thành 0

            int bestScore = ScoreManager.instance.GetBestScore(); // Lấy điểm cao nhất của người chơi

            uiManager.ShowRequiredScore(nextLevelRequiredScore, bestScore);
        }
    


        onLevelButtonClicked?.Invoke();
    }

    private void UpdateLevelButtonsInteractablity()
    {
        int bestScore = ScoreManager.instance.GetBestScore();

        for (int i = 0; i < levelDatas.Length; i++)
        {
            LevelButton levelButton = levelButtonParents[i].GetChild(0).GetComponent<LevelButton>();
            int requiredScore = levelDatas[i].GetRequiredHighscore();

            levelButton.Configure(i + 1, requiredScore, bestScore);
        }
    }
}
