using UnityEngine.Analytics;
using UnityEngine;

public static class PrefConst
{
    public const string MUSIC_VOLUME_KEY = "music_volume";
    public static float MUSIC_VOLUME
    {
        set => PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, value);
        get => PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 0); // Replace 0 with a default value if needed.  
    }
    
    public const string SFX_VOLUME_KEY = "sfx_volume";
    public static float SFX_VOLUME
    {
        set => PlayerPrefs.SetFloat(SFX_VOLUME_KEY, value);
        get => PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 0); // Replace 0 with a default value if needed.  
    }

}
