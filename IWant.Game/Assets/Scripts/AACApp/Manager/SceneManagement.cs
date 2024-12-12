using Assets.Scripts.Utility.Const;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private SceneName sceneName;
    public void ChangeScene()
    {
        if (sceneName != SceneName.Null)
        {
            SceneManager.LoadScene(sceneName.ToString());
        }
    }

}
