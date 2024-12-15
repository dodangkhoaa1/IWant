using Assets.Scripts.Utility.Const;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button registerButton;
    public Button loginButton;
    public Button logoutButton;
    public Button playButton;

    [SerializeField]
    private TextMeshProUGUI playerDisplay;
    [SerializeField] 
    private LocalizedString localizedPlayerDisplay; // Localized string for "Player: {0}"
    private void OnEnable()
    {
        localizedPlayerDisplay.StringChanged += UpdatePlayerDisplay;
    }

    private void OnDisable()
    {
        localizedPlayerDisplay.StringChanged -= UpdatePlayerDisplay;
    }
    private void UpdatePlayerDisplay(string value)
    {
        // Update the text with the localized value
        playerDisplay.text = value;
    }

    private void Start()
    {
        if (DBManager.LoggedIn)
        {

            localizedPlayerDisplay.Arguments = new object[] { DBManager.username };
            localizedPlayerDisplay.TableEntryReference = "notifyLoggedIn"; // Pass the username
        }
        else
        {
            localizedPlayerDisplay.Arguments = null; // No arguments needed
            localizedPlayerDisplay.TableEntryReference = "notifyNotLoggedIn";
        }

        localizedPlayerDisplay.RefreshString(); // Refresh the string to apply changes

        // Update button states
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
