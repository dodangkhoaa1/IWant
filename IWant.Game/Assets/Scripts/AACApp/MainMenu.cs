using Assets.Scripts.Utility.Const;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button registerButton;
    public Button loginButton;
    public Button logoutButton;
    public Button playButton;


    public TextMeshProUGUI playerDisplay;
    private void Start()
    {

        if (DBManager.LoggedIn)
        {
            playerDisplay.text = $"Player: {DBManager.username}";
            
        }
        logoutButton.gameObject.SetActive(DBManager.LoggedIn);
        registerButton.interactable = !DBManager.LoggedIn;
        loginButton.interactable = !DBManager.LoggedIn;
        playButton.interactable = DBManager.LoggedIn;
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene(SceneName.RegisterScene.ToString());
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene(SceneName.LoginScene.ToString());
    }
    public void GoToGame()
    {
        SceneManager.LoadScene(SceneName.GameAAC.ToString());
    }


}
