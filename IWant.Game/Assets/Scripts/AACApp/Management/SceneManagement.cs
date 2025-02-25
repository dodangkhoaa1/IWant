using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Allow to go to the home scene
    public void GoToHome()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }

    // Allow to reload the current scene
    public void ReLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Allow to return to the menu scene
    public void ReturnMenu()
    {
        SceneManager.LoadScene(SceneName.MenuColor.ToString());
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
