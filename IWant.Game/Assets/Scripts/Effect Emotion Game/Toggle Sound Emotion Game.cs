using UnityEngine;
using UnityEngine.UI;

public class ToggleSoundEmotionGame : MonoBehaviour
{
    public Toggle toggle;         // Kéo Toggle vào đây
    public AudioSource audioSource;  // Kéo AudioSource vào đây
    public AudioClip clickSound;  // Kéo file âm thanh vào đây

    void Start()
    {
        if (toggle != null)
        {
            // Gán sự kiện khi Toggle thay đổi
            toggle.onValueChanged.AddListener(PlayClickSound);
        }
    }

    void PlayClickSound(bool isOn)
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
