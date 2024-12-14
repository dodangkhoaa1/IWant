using Unity.VisualScripting;
using UnityEngine;

public class AudioManagegement : MonoBehaviour
{
    public static AudioManagegement instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
