using Connect.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerDotGame : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private AudioSource buttonClickSource;
    [SerializeField] private AudioSource nodeSource;
    [SerializeField] private AudioSource nodeErrorSource;
    [SerializeField] private AudioSource bgmSource;  // AudioSource cho nhạc nền

    [Header(" Sounds ")]
    [SerializeField] private AudioClip nodeClips;
    [SerializeField] private AudioClip nodeErrorClips;
    [SerializeField] private AudioClip backgroundMusic;  // AudioClip nhạc nền

    private static AudioManagerDotGame instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        GameplayManagerDotGame.onNodeSolvedError += PlayNodeErrorSound;
        GameplayManagerDotGame.onNodeClicked += ConnectNodeCallback;
        SettingsManagerEmotionGame.onSFXValueChanged += SFXValueChangedCallback;
        SettingsManagerEmotionGame.onBGMValueChanged += BGMValueChangedCallback;
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
        if (scene.name == SceneName.MainMenu.ToString())
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameplayManagerDotGame.onNodeSolvedError -= PlayNodeErrorSound;
        GameplayManagerDotGame.onNodeClicked -= ConnectNodeCallback;
        SettingsManagerEmotionGame.onBGMValueChanged -= BGMValueChangedCallback;
        SettingsManagerEmotionGame.onSFXValueChanged -= SFXValueChangedCallback;
    }

    private List<AudioSource> sfxSources = new List<AudioSource>();
    private bool sfxActive = true;

    private void Start()
    {
        PlayBackgroundMusic();
        BGMValueChangedCallback(PlayerPrefs.GetInt("bgmActiveKey", 1) == 1);

        // Check if nodeSource exists, if not create it
        if (nodeSource == null)
        {
            nodeSource = gameObject.AddComponent<AudioSource>();
            nodeSource.clip = nodeClips;
            nodeSource.playOnAwake = false;
        }
    }

    //node
    public void ConnectNodeCallback()
    {
        PlayNodeSound();
    }

    public void PlayNodeSound()
    {
        if (nodeSource != null && nodeClips != null)
        {
            nodeSource.clip = nodeClips;
            nodeSource.Play();
        }
    }
    //node error
    public void PlayNodeErrorSound()
    {
        if (nodeErrorSource != null && nodeErrorClips != null)
        {
            nodeErrorSource.clip = nodeErrorClips;
            nodeErrorSource.Play();
        }
    }
    //BGM
    public void BGMValueChangedCallback(bool bgmActive)
    {
        if (bgmSource != null)
        {
            bgmSource.mute = !bgmActive;
        }
    }

    public void PlayBackgroundMusic()
    {
        if (bgmSource != null && backgroundMusic != null)
        {
            bgmSource.clip = backgroundMusic;
            bgmSource.loop = true;  // Lặp lại nhạc nền
            bgmSource.Play();
        }
    }

    //SFX
    public void SFXValueChangedCallback(bool sfxActive)
    {
        this.sfxActive = sfxActive;

        // Xóa những AudioSource đã bị hủy
        sfxSources.RemoveAll(source => source == null);

        foreach (var source in sfxSources)
        {
            if (source != null)
            {
                source.mute = !sfxActive;
            }
        }

        // Mute/unmute node sound
        if (nodeSource != null)
        {
            nodeSource.mute = !sfxActive;
        }

        if (buttonClickSource != null)
        {
            buttonClickSource.mute = !sfxActive;
        }
        if (nodeErrorSource != null)
        {
            nodeErrorSource.mute = !sfxActive;
        }
    }
}
