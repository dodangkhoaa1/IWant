using UnityEngine;

#nullable enable
public class AudioManager : MonoBehaviour
{
    private static AudioManager? _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("AudioManager");
                obj.AddComponent<AudioSource>();
                _instance = obj.AddComponent<AudioManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }
}
