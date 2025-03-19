using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManagerEmotionGame : MonoBehaviour
{
    public static GameManagerEmotionGame instance;

    [Header(" Settings ")]
    private GameState gameState;
    private GameoverManagerEmotionGame gameoverManager;

    [Header(" Actions ")]
    public static Action<GameState> onGameStateChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // Nếu cần giữ GameManager qua các scene khác, uncomment dòng dưới đây:
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SetMenu();
    }

    void Update()
    {
        
    }

    private void SetMenu()
    {
        SetGameState(GameState.Menu);
        
    }

    private void SetGame()
    {
        // Load level mới
        if (LevelManagerEmotionGame.instance != null)
        {
            LevelManagerEmotionGame.instance.LoadCurrentLevel();
        }

        // Reset thời gian và điểm cho level mới
        if (TimeManagerEmotionGame.instance != null)
        {
            TimeManagerEmotionGame.instance.StartTimer();
        }

        if (ScoreManagerEmotionGame.instance != null)
        {
            ScoreManagerEmotionGame.instance.ResetLevelScore();
        }

        SetGameState(GameState.Game);
    }
    private void SetGameover()
    {
        // Dừng timer khi game kết thúc
        if (TimeManagerEmotionGame.instance != null)
        {
            TimeManagerEmotionGame.instance.StopTimer();
        }

        SetGameState(GameState.Gameover);
    }

    public void SetGameState(GameState newState)
    {
        gameState = newState;
        onGameStateChanged?.Invoke(newState);
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    // Phương thức này dùng để chuyển sang trạng thái Game, được gọi từ UI (ví dụ: nút Play)
    public void SetGameState()
    {
        SetGame();
    }

    // Phương thức chuyển về Menu (ví dụ: khi bấm nút Menu trong UI)
    public void SetMenuState()
    {
        SetMenu();
    }

    public bool IsGameState()
    {
        return gameState == GameState.Game;
    }

    public void SetGameoverState()
    {
        SetGameover();
        //gameoverManager.TriggerGameOver();
    }
}   
