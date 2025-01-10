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
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;

        if(volume == minVolumeSlider){
            musicDisplay.sprite = musicOff;
            musicEnabled = false;
        }else{
            musicDisplay.sprite = musicOn;
            musicEnabled = true;
        }

        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PrefConst.MUSIC_VOLUME = volume;
    }
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;

        if (volume == minVolumeSlider)
        {
            sfxDisplay.sprite = sfxOff;
            musicEnabled = false;
        }
        else
        {
            sfxDisplay.sprite = sfxOn;
            musicEnabled = true;
        }

        myMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PrefConst.SFX_VOLUME = volume;
    }

    private void LoadVolume()
    {
        musicSlider.value = PrefConst.MUSIC_VOLUME;
        SetMusicVolume();

        sfxSlider.value = PrefConst.SFX_VOLUME;
        SetSFXVolume();
    }

    private void TurnOffMusic()
    {
        if (musicSlider.value != minVolumeSlider)
            oldMusicVolume = musicSlider.value;
        musicSlider.value = minVolumeSlider;
    }

    private void TurnOnMusic()
    {
        musicSlider.value = oldMusicVolume;
    }

    public void OnClickMusic()
    {
        if (musicEnabled) TurnOffMusic();
        else TurnOnMusic();
        musicEnabled = !musicEnabled;
    }
    
    public void OnClickSFX()
    {
        if (musicEnabled) TurnOffSFX();
        else TurnOnSFX();
        sfxEnabled = !sfxEnabled;
    }

    private void TurnOffSFX()
    {
        if (sfxSlider.value != minVolumeSlider)
            oldSFXVolume = sfxSlider.value;
        sfxSlider.value = minVolumeSlider;
    }

    private void TurnOnSFX()
    {
        sfxSlider.value = oldSFXVolume;
    }
}
