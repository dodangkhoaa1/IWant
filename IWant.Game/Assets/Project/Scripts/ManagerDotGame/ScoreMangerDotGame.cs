using Connect.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreMangerDotGame : MonoBehaviour
{
    public static ScoreMangerDotGame instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    [SerializeField] private TMP_Text _highScoreText; // Thêm trường để hiển thị điểm số cao nhất

        private void OnEnable()
        {
            GameplayManagerDotGame.OnHighScoreChanged += UpdateHighScoreUI;
        }

        private void OnDisable()
        {
            GameplayManagerDotGame.OnHighScoreChanged -= UpdateHighScoreUI;
        }

        private void Start()
        {
            UpdateHighScoreUI(GameplayManagerDotGame.Instance.HighScore);
        }

    public void UpdateHighScoreUI(int newHighScore)
    {
        _highScoreText.text = newHighScore.ToString();
    }
    public int GetScore()
    {
        int bestScore = PlayerPrefs.GetInt("HighScoreDotGame", 0);
        return bestScore;
    }

}
