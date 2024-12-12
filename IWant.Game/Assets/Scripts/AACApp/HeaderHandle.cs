using Assets.Scripts.Utility.Const;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeaderHandle : MonoBehaviour
{
    public void GoToMenu(){
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }
}
