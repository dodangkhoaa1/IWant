using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class ScoreManagerEmotionGame : MonoBehaviour
{
    public static ScoreManagerEmotionGame instance;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI gameScoreText;
    [SerializeField] private TextMeshProUGUI menuBestScoreText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private int baseScore = 2000;
    private int score, bestScore;
    private float levelStartTime; // thời điểm bắt đầu màn chơi

    private const string bestScoreKey = "bestScoreKey";

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        LoadData();
        GameManagerEmotionGame.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        GameManagerEmotionGame.onGameStateChanged -= GameStateChangedCallback;
    }

    private void Start()
    {
        levelStartTime = Time.time;
        UpdateScoreText();
        UpdateBestScoreText();
    }

    private void GameStateChangedCallback(GameState gameState)
    {
        if (gameState == GameState.Gameover)
        {
            CalculateBestScore();
            // Sau khi tính điểm cao nhất, cập nhật lại UI điểm cao nhất:
            UpdateBestScoreText();
        }
    }

    public void LevelCompleted()
    {
        float timeTaken = Time.time - levelStartTime;
        int penaltyPerSecond = 10;
        int levelScore = Mathf.Max(0, baseScore - (int)(timeTaken * penaltyPerSecond));

        score += levelScore;
        Debug.Log($"Level completed in {timeTaken:F2}s, Level Score: {levelScore}, Total Score: {score}");

        if (HUDManagerEmotionGame.instance != null)
            HUDManagerEmotionGame.instance.UpdateScoreDisplay(score);

        UpdateScoreText();
        UpdateLevelScoreText(score);
        // Reset thời gian bắt đầu cho level mới
        ResetLevelScore();
    }

    private void UpdateLevelScoreText(int levelScore)
    {
        if (gameOverScoreText != null)
            gameOverScoreText.text = $"{score}";
    }
    private void UpdateScoreText()
    {
        if (gameScoreText != null)
            gameScoreText.text = score.ToString();
    }

    private void UpdateBestScoreText()
    {
        if (menuBestScoreText != null)
            menuBestScoreText.text = bestScore.ToString();
    }

    private void CalculateBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            SaveData();
        }
    }

    private void LoadData()
    {
        bestScore = PlayerPrefs.GetInt(bestScoreKey, 0);
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(bestScoreKey, bestScore);
        PlayerPrefs.Save();
    }

    // Chỉ reset thời gian bắt đầu của level mới, không reset score
    public void ResetLevelScore()
    {
        levelStartTime = Time.time;
    }
      // New method to reset the total score
    public void ResetTotalScore()
    {
        score = 0;
        UpdateScoreText();
        Debug.Log("Total score reset");
    }
    public int GetCurrentScore()
    {
        return score;
    }
    public int TotalScore()
    {
        return score;
    }
    public int GetBestScore()
    {
        return bestScore;
    }   
}
