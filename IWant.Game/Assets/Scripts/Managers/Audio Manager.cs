using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private AudioSource mergeSource;
    [SerializeField] private AudioSource bgmSource;  // AudioSource cho nhạc nền
    [SerializeField] private AudioSource gameOverSource;  // AudioSource cho nhạc Game Over

    [Header(" Sounds ")]
    [SerializeField] private AudioClip[] mergeClips;
    [SerializeField] private AudioClip backgroundMusic;  // AudioClip nhạc nền
    [SerializeField] private AudioClip gameOverMusic;  // AudioClip nhạc Game Over

    private void Awake()
    {
        MergeManager.onMergeProcess += MergeProcessedCallBack;
        SettingsManager.onSFXValueChanged += SFXValueChangedCallback;
        SettingsManager.onBGMValueChanged += BGMValueChangedCallback;
    }

    private void OnDestroy()
    {
        MergeManager.onMergeProcess -= MergeProcessedCallBack;
        SettingsManager.onSFXValueChanged -= SFXValueChangedCallback;
        SettingsManager.onBGMValueChanged -= BGMValueChangedCallback;
    }

    private void Start()
    {
        PlayBackgroundMusic();
        BGMValueChangedCallback(PlayerPrefs.GetInt("bgmActiveKey", 1) == 1);  // Áp dụng trạng thái ban đầu
    }

    private void MergeProcessedCallBack(FruitType fruitType, Vector2 mergePos)
    {
        PlayMergeSound();
    }

    public void BGMValueChangedCallback(bool bgmActive)
    {
        if (bgmSource != null)
        {
            bgmSource.mute = !bgmActive;
        }
    }

    public void PlayMergeSound()
    {
        if (mergeSource != null && mergeClips.Length > 0)
        {
            mergeSource.clip = mergeClips[Random.Range(0, mergeClips.Length)];
            mergeSource.Play();
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
    public void PlayGameOverMusic()
    {
        if (gameOverSource != null && gameOverMusic != null)
        {
            bgmSource.Stop();  // Dừng nhạc nền
            gameOverSource.clip = gameOverMusic;
            gameOverSource.loop = false;  // Không lặp lại nhạc Game Over
            gameOverSource.Play();
        }
    }
    public void SFXValueChangedCallback(bool sfxActive)
    {
        if (mergeSource != null)
        {
            mergeSource.mute = !sfxActive;
        }
    }
}
