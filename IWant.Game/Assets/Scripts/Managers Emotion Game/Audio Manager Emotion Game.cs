using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerEmotionGame : MonoBehaviour
{
    public static AudioManagerEmotionGame instance;
    [Header(" Elements ")]
    [SerializeField] private AudioSource clickButtonSource;
    [SerializeField] private AudioSource bgmSource;  // AudioSource cho nhạc nền
    [SerializeField] private AudioSource gameOverSource;  // AudioSource cho nhạc Game Over

    [Header(" Sounds ")]
    [SerializeField] private AudioClip backgroundMusic;  // AudioClip nhạc nền
    [SerializeField] private AudioClip gameOverMusic;  // AudioClip nhạc Game Over

    private List<AudioSource> sfxSources = new List<AudioSource>(); // Danh sách lưu các AudioSource cho SFX
    private bool sfxActive = true; // Trạng thái của SFX

    private void Awake()
    {
        // Kiểm tra xem đã có instance chưa
        if (instance == null)
        {
            instance = this; // Gán instance hiện tại
        }
        else
        {
            Destroy(gameObject); // Nếu đã có một instance, xóa object mới để tránh trùng lặp
            return;
        }

        DontDestroyOnLoad(gameObject); // Giữ lại AudioManager khi load scene mới

        SettingsManagerEmotionGame.onSFXValueChanged += SFXValueChangedCallback;
        SettingsManagerEmotionGame.onBGMValueChanged += BGMValueChangedCallback;
    }

    private void OnDestroy()
    {
        
        SettingsManagerEmotionGame.onBGMValueChanged -= BGMValueChangedCallback;
        SettingsManagerEmotionGame.onSFXValueChanged -= SFXValueChangedCallback;
        // Xóa tất cả SFX đã đăng ký khi AudioManager bị hủy
        sfxSources.Clear();
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

    private void Start()
    {
        PlayBackgroundMusic();
        BGMValueChangedCallback(PlayerPrefs.GetInt("bgmActiveKey", 1) == 1);
        SFXValueChangedCallback(PlayerPrefs.GetInt("sfxActiveKey", 1) == 1);
    }



    public void BGMValueChangedCallback(bool bgmActive)
    {
        if (bgmSource != null)
        {
            bgmSource.mute = !bgmActive;
        }
    }

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
        if (clickButtonSource != null)
        {
            clickButtonSource.mute = !sfxActive;
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
    public void PlaySFX(AudioSource source, AudioClip clip)
    {
        if (sfxActive && source != null && clip != null)
        {
            if (source.gameObject.activeInHierarchy) // Kiểm tra nếu object còn tồn tại
            {
                source.PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning("[AudioManager] Attempted to play SFX on a destroyed AudioSource.");
            }
        }
    }

    public void RegisterSFXSource(AudioSource source)
    {
        if (!sfxSources.Contains(source))
        {
            sfxSources.Add(source);
        }
    }
    public void PlayGameOverMusic()
    {
        if (gameOverSource != null && gameOverMusic != null)
        {
            gameOverSource.clip = gameOverMusic;
            gameOverSource.loop = false;
            gameOverSource.Play();
        }
        else
        {
            Debug.LogError("GameOverSource or GameOverMusic is not set.");
        }
    }
    //library
    public void PlayLibrarySound(AudioClip clip)
    {
        if (sfxActive && clip != null)
        {
            AudioSource tempSource = gameObject.AddComponent<AudioSource>();
            tempSource.clip = clip;
            tempSource.PlayOneShot(clip);
            Destroy(tempSource, clip.length); // Xóa AudioSource sau khi phát xong
        }
    }
}
