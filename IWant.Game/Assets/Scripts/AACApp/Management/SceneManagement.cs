using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Allow to reload the current scene
    public void ReLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string sceneName = "MainMenu")
    {
        SceneManager.LoadScene(sceneName);
    }
}
