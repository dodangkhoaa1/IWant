using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderVolumeSettings : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [Header("Display Image")]
    [SerializeField] private Image musicDisplay;
    [SerializeField] private Image sfxDisplay;

    [Header("Sprites")]
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;

    [SerializeField] private Sprite sfxOn;
    [SerializeField] private Sprite sfxOff;

    private bool musicEnabled = true;
    private bool sfxEnabled = true;

    private float minVolumeSlider;

    //store previous volume
    private float oldMusicVolume;
    private float oldSFXVolume;

    private void Start()
    {
        minVolumeSlider = musicSlider.minValue;
        oldMusicVolume = PrefConst.MUSIC_VOLUME;
        oldSFXVolume = PrefConst.SFX_VOLUME;

        if (PlayerPrefs.HasKey(PrefConst.MUSIC_VOLUME_KEY) ||
            PlayerPrefs.HasKey(PrefConst.SFX_VOLUME_KEY))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    // Allow to set the music volume
    public void SetMusicVolume()
    {
        SetVolume(musicSlider, musicDisplay, musicOn, musicOff, "music", ref musicEnabled, ref oldMusicVolume);
        PrefConst.MUSIC_VOLUME = musicSlider.value;
    }

    // Allow to set the SFX volume
    public void SetSFXVolume()
    {
        SetVolume(sfxSlider, sfxDisplay, sfxOn, sfxOff, "sfx", ref sfxEnabled, ref oldSFXVolume);
        PrefConst.SFX_VOLUME = sfxSlider.value;
    }

    private void SetVolume(Slider slider, Image display, Sprite onSprite, Sprite offSprite, string mixerParam, ref bool enabledFlag, ref float oldVolume)
    {
        float volume = slider.value;

        if (volume == minVolumeSlider)
        {
            display.sprite = offSprite;
            enabledFlag = false;
        }
        else
        {
            display.sprite = onSprite;
            enabledFlag = true;
        }

        myMixer.SetFloat(mixerParam, Mathf.Log10(volume) * 20);
    }

    // Allow to load the volume settings
    private void LoadVolume()
    {
        musicSlider.value = PrefConst.MUSIC_VOLUME;
        SetMusicVolume();

        sfxSlider.value = PrefConst.SFX_VOLUME;
        SetSFXVolume();
    }

    // Allow to turn off the music
    private void TurnOffMusic()
    {
        if (musicSlider.value != minVolumeSlider)
            oldMusicVolume = musicSlider.value;
        musicSlider.value = minVolumeSlider;
    }

    // Allow to turn on the music
    private void TurnOnMusic()
    {
        musicSlider.value = oldMusicVolume;
    }

    // Allow to handle music button click
    public void OnClickMusic()
    {
        if (musicEnabled) TurnOffMusic();
        else TurnOnMusic();
        musicEnabled = !musicEnabled;
    }

    // Allow to handle SFX button click
    public void OnClickSFX()
    {
        if (sfxEnabled) TurnOffSFX();
        else TurnOnSFX();
        sfxEnabled = !sfxEnabled;
    }

    // Allow to turn off the SFX
    private void TurnOffSFX()
    {
        if (sfxSlider.value != minVolumeSlider)
            oldSFXVolume = sfxSlider.value;
        sfxSlider.value = minVolumeSlider;
    }

    // Allow to turn on the SFX
    private void TurnOnSFX()
    {
        sfxSlider.value = oldSFXVolume;
    }
}
