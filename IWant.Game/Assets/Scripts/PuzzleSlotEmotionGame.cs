using UnityEngine;
using EasyUI.Toast; // Thêm thư viện Toast

public class PuzzleSlotEmotionGame : MonoBehaviour
{
    public SpriteRenderer Renderer;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _completeClip;

    [SerializeField] private string slotName; // Tên của slot

    private void Start()
    {
        if (AudioManagerEmotionGame.instance != null)
        {
            AudioManagerEmotionGame.instance.RegisterSFXSource(_source);
        }
    }

    public void Placed()
    {
        if (AudioManagerEmotionGame.instance != null)
        {
            AudioManagerEmotionGame.instance.PlaySFX(_source, _completeClip);
        }

        // Hiển thị thông báo Toast thay vì hiển thị TextMeshProUGUI
        Toast.Show($"{slotName}", 2f, ToastColor.Green, ToastPosition.BottomCenter);

        Debug.Log($"PuzzleSlot {slotName} đã được đặt!");
    }

    public string GetSlotName()
    {
        return slotName;
    }
}
