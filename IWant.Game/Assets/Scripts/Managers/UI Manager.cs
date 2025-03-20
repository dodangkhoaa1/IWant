using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private TMP_Text requiredScoreText;
    [SerializeField] private TMP_Text gameoverScoreText; // Add this line

    [Header(" Actions ")]
    public static Action onMapOpened;

    private void Awake()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
        LevelMapManager.onLevelButtonClicked += LevelButtonCallBack;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
        LevelMapManager.onLevelButtonClicked -= LevelButtonCallBack;
    }

    void Start()
    {
        requiredScoreText.gameObject.SetActive(false);
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
    //Set
    private void SetMenu()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        settingsPanel.SetActive(false);
        mapPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

    private void SetGame()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        mapPanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    private void SetGameover()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(true);
        gameoverScoreText.text = ScoreManager.instance.GetScore().ToString(); // Add this line

    }

    //
    public void LevelButtonCallBack()
    {
        GameManager.instance.SetGameState();
        SetGame();
    }
    //back
    public void OnBackLevelPanel()
    {
        // Reset lại trạng thái game
        GameManager.instance.ResetGame();

        // Hiển thị mapPanel thay vì menuPanel
        mapPanel.SetActive(true);

        // Ẩn các panel khác
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
    }
    public void OnBackMenuPanel()
    {
        // Reset lại trạng thái game
        GameManager.instance.ResetGame();
        SetMenu();


    }
    //setting
    public void SettingsButtonCallBack()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
    //shop
    public void ShopButtonCallback()
    {
        shopPanel.SetActive(true);

        PauseGame(); // Pause the game when the shop panel is opened
    }

    public void CloseShopPanel()
    {
        shopPanel.SetActive(false);
        ResumeGame(); // Resume the game when the shop panel is closed
    }
    //map
    public void OpenMap()
    {
        mapPanel.SetActive(true);

        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);

        onMapOpened?.Invoke();
    }
    //replay 
    public void CloseMap()
    {
        mapPanel.SetActive(false);
    }

    public void QuitGameButtonCallBack()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());

    }

    public void ShowRequiredScore(int nextLevelRequiredScore, int bestScore)
    {
        if (nextLevelRequiredScore > 0)
        {
            requiredScoreText.gameObject.SetActive(true);

            if (bestScore >= nextLevelRequiredScore)
            {
                requiredScoreText.text = "You have enough points to pass the level";
            }
            else
            {
                requiredScoreText.text = $"You need {nextLevelRequiredScore} points to unlock the next level";
            }
        }
        else
        {
            requiredScoreText.gameObject.SetActive(false);
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
