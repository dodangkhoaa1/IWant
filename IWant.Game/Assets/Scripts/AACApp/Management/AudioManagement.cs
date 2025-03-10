using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManagement : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Sounds")]
    [SerializeField] private AudioClip backgroundMusic;

    public static AudioManagement instance { get; private set; }

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FruitDrop")
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        sfxSource.clip = audioClip;
        sfxSource.Play();
    }
}
