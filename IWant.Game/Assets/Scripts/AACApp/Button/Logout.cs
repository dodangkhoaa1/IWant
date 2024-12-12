using Assets.Scripts.Utility.Const;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
    public void CallLogout()
    {
        DBManager.LogOut();
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }

}
