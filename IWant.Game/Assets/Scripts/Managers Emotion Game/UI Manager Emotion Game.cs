using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using System.Collections;

public class UIManagerEmotionGame : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject pausedPanel;
    [SerializeField] private GameObject libraryPanel;
    [SerializeField] private GameObject journalPanel;

    [Header(" Actions ")]
    public static Action onGameOpened;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        GameManagerEmotionGame.onGameStateChanged += GameStateChangedCallback;
        UIManagerEmotionGame.onGameReplay += SetGame; // Lắng nghe sự kiện replay

    }
    private void OnDestroy()
    {
        GameManagerEmotionGame.onGameStateChanged -= GameStateChangedCallback;
        UIManagerEmotionGame.onGameReplay -= SetGame;

    }
    public static Action onGameReplay;
    void Start()
    {
        //SetMenu();
    }

    void Update()
    {

    }

    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Menu:
                SetMenu();
                break;
            case GameState.Game:
                SetGame();
                break;
            case GameState.Gameover:
                SetGameover();
                break;
        }
    }
    private void SetMenu()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        settingsPanel.SetActive(false);
        pausedPanel.SetActive(false);
        libraryPanel.SetActive(false);
        journalPanel.SetActive(false);
    }
    private void SetGame()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameoverPanel.SetActive(false);
        settingsPanel.SetActive(false);
        pausedPanel.SetActive(false);
        libraryPanel.SetActive(false);
        journalPanel.SetActive(false);
    }
    private void SetGameover()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(true);
        settingsPanel.SetActive(false);
        pausedPanel.SetActive(false);
        libraryPanel.SetActive(false);
        journalPanel.SetActive(false);
    }
    private void SetLibrary()
    {
        libraryPanel.SetActive(true);
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        settingsPanel.SetActive(false);
        pausedPanel.SetActive(false);
        journalPanel.SetActive(false);
    }
    private void SetJournal()
    {
        journalPanel.SetActive(true);
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        settingsPanel.SetActive(false);
        pausedPanel.SetActive(false);
        libraryPanel.SetActive(false);
    }
    public void LevelButtonCallBack()
    {
        SetGame();
    }
    public void NextButtonCallBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(0);
    }
    //Setting
    public void SettingsButtonCallBack()
    {
        settingsPanel.SetActive(true);
    }
    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
    //Paused
    public void TogglePause()
    {
        bool isPaused = !pausedPanel.activeSelf;
        pausedPanel.SetActive(isPaused);

        // Dừng hoặc tiếp tục game nhưng giữ lại UI gamePanel
        Time.timeScale = isPaused ? 0 : 1;
    }
    //Button Play
    public void OpenGame()
    {
        SetGame();
        GameManagerEmotionGame.instance.SetGameState();
        LevelManagerEmotionGame.instance.LoadCurrentLevel();
    }

    public void ReplayGame()
    {
        // Reset the level index to start from the beginning
        LevelManagerEmotionGame.instance.ResetLevelIndex();

        // Set the game state to Game
        GameManagerEmotionGame.instance.SetGameState();

        // Gọi sự kiện để UIManager tự cập nhật
        UIManagerEmotionGame.onGameReplay?.Invoke();

        // Reset thời gian và điểm
        TimeManagerEmotionGame.instance?.ResetTimer();
        TimeManagerEmotionGame.instance?.StartTimer();
        ScoreManagerEmotionGame.instance?.ResetTotalScore(); // Reset the total score

        // Load lại level
        LevelManagerEmotionGame.instance?.LoadCurrentLevel();

        // Transition to the game panel
        SetGame();

        Debug.Log("Game replayed successfully");
    }

    //Button Library
    public void LibraryButtonCallBack()
    {
        SetLibrary();
    }
    //Button Journal
    public void JournalButtonCallBack()
    {
        SetJournal();
    }
    public void QuitGameButtonCallBack()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }
}
