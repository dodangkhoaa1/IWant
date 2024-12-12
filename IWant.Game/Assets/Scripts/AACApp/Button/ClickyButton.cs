using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _img;
    [SerializeField] private AudioClip _compressClip, _uncompressClip;
    [SerializeField] private AudioSource _source;

    public void OnPointerDown(PointerEventData eventData)
    {
        _source.PlayOneShot(_uncompressClip);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _source.PlayOneShot(_compressClip);
    }
}
