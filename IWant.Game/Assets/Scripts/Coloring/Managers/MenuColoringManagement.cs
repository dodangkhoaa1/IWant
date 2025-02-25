using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#nullable enable
public class MenuColoringManagement : MonoBehaviour
{
    [SerializeField] private PictureData[] picturesToColor;
    public static MenuColoringManagement? instance { get; private set; }

    public PictureData[] PicturesToColor => picturesToColor;

    [HideInInspector]
    public int INDEX_OF_CHOSE_PICTURE;
    public Category INDEX_OF_CHOSE_CATEGORY;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
}
