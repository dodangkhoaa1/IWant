using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PictureSpawner : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform pictureContainer;

    private PictureData[] picturesToColor;

    // Allow to set the screen orientation to portrait mode
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Allow to initialize pictures to color and spawn menu pictures
    private void Start()
    {
        picturesToColor = MenuColoringManagement.instance.PicturesToColor;
        SpawnMenuPictures();
    }

    // Allow to spawn menu pictures with buttons
    private void SpawnMenuPictures()
    {
        for (int i = 0; i < picturesToColor.Length; i++)
        {
            if (picturesToColor[i].CategoryName != MenuColoringManagement.instance.INDEX_OF_CHOSE_CATEGORY) continue;
            GameObject buttonGO = Instantiate(buttonPrefab, pictureContainer);
            buttonGO.transform.GetChild(0).GetComponent<Image>().sprite = picturesToColor[i].Sprite;
            buttonGO.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE ? picturesToColor[i].EnglishName : picturesToColor[i].VietnameseName;

            int index = i;
            buttonGO.GetComponent<Button>().onClick.AddListener(() => ChoosePicture(index));
        }
    }

    // Allow to choose a picture and load the coloring game scene
    private void ChoosePicture(int indexOfPicture)
    {
        MenuColoringManagement.instance.INDEX_OF_CHOSE_PICTURE = indexOfPicture;
        SceneManager.LoadScene(SceneName.ColoringGame.ToString());
    }
}
