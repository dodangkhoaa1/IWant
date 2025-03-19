using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header(" Settings ")]
    private GameState gameState;

    [Header(" Actions ")]
    public static Action<GameState> onGameStateChanged;

    [Header(" Level Data ")]
    private LevelDataSO currentLevelData; // Lưu dữ liệu màn chơi hiện tại
    private static LevelDataSO savedLevelData;

    [Header(" UI Elements ")]
    [SerializeField] private TextMeshProUGUI requiredScoreText;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetMenu()
    {
       SetGameState(GameState.Menu);
    }
    private void SetGame()
    {
       SetGameState(GameState.Game);
    }
    private void SetGameover()
    {
        SetGameState(GameState.Gameover);
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);  
    }
    public GameState GetGameState()
    {
        return gameState;
    }

    public void SetGameState()
    {
        SetGame();
    }
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
    }
    public void SetCurrentLevel(LevelDataSO levelData)
    {
        currentLevelData = levelData;
        UpdateRequiredScoreText();
    }
    public LevelDataSO GetCurrentLevel()
    {
        return currentLevelData;
    }

    private void UpdateRequiredScoreText()
    {
        if (requiredScoreText == null || currentLevelData == null) return;

        int requiredScore = currentLevelData.GetRequiredHighscore();
        requiredScoreText.text = $"You need {requiredScore} points to pass the level!";
    }
}
