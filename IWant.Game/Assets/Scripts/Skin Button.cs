using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Button button;
    [SerializeField] private Image iconImage;
    [SerializeField] private GameObject selectionOutline;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public void Configure(Sprite sprite)
    {
        iconImage.sprite = sprite;
    }

    public Button GetButton() => button;

    public void Select() => selectionOutline.SetActive(true);
    public void Unselect() => selectionOutline.SetActive(false);
}
