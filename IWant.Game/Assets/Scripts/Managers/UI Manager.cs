using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

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
        //SetMenu();
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
    private void SetMenu()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        settingsPanel.SetActive(false);
        mapPanel.SetActive(false);
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
    }

    public void LevelButtonCallBack()
    {
        GameManager.instance.SetGameState();
        SetGame();
    }
    public void NextButtonCallBack()
    {
        //SceneManager.LoadScene(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       //ameManager.instance.SetMenuState();
    }

    public void SettingsButtonCallBack()
    {
        settingsPanel.SetActive(true);
    }
    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    public void ShopButtonCallback() => shopPanel.SetActive(true);
    public void CloseShopPanel() => shopPanel.SetActive(false);

    public void OpenMap()
    {
        mapPanel.SetActive(true);

        onMapOpened?.Invoke();
    }

    public void CloseMap() => mapPanel.SetActive(false);
    public void QuitGameButtonCallBack()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }

    public void ShowRequiredScore(int nextLevelRequiredScore, int bestScore)
    {
        if (nextLevelRequiredScore > 0) // Kiểm tra level tiếp theo có tồn tại
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
}
