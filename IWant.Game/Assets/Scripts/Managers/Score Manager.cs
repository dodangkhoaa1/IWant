    using UnityEngine;
    using TMPro;
    using System;

    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;

        [Header(" Elements ")]
        [SerializeField] private TextMeshProUGUI gameScoreText;
        [Header(" Settings ")]
        [SerializeField] private float scoreMultiplier;
        private int score, bestScore;

        [Header(" Data ")]
        private const string bestScoreKey = "bestScoreKey";
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            LoadData();
            MergeManager.onMergeProcess += MergeProcessedCallBack;

            GameManager.onGameStateChanged += GameStateChangedCallback;
        }
        private void OnDestroy()
        {
            MergeManager.onMergeProcess -= MergeProcessedCallBack;
            GameManager.onGameStateChanged -= GameStateChangedCallback;

        }

        void Start()
        {
            UpdateScoreText();


        }

        void Update()
        {
      
        }
        public int GetBestScore()
        {
            return bestScore;
        }
    public int GetScore()
    {
        return score;
    }
        private void GameStateChangedCallback(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Gameover:
                    CalculateBestScore();
                    break;
            }
        }
        private void MergeProcessedCallBack(FruitType fruitType, Vector2 unused)
        {
            int scoreToAdd = (int)fruitType;
            score += (int)(scoreToAdd * scoreMultiplier);

            UpdateScoreText();

        }

        private void UpdateScoreText()
        {
            gameScoreText.text = score.ToString();
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
            bestScore = PlayerPrefs.GetInt(bestScoreKey);
        }

        private void SaveData()
        {
            PlayerPrefs.SetInt(bestScoreKey, bestScore);
        }
    }
