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

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    private void Start()
    {
        picturesToColor = MenuColoringManagement.instance.PicturesToColor;
        SpawnMenuPictures();
    }

    private void SpawnMenuPictures()
    {
        for (int i = 0; i < picturesToColor.Length; i++)
        {
            GameObject buttonGO = Instantiate(buttonPrefab, pictureContainer);
            buttonGO.transform.GetChild(0).GetComponent<Image>().sprite = picturesToColor[i].Sprite;
            buttonGO.GetComponentInChildren<TextMeshProUGUI>().text = picturesToColor[i].Name;

            int index = i;
            buttonGO.GetComponent<Button>().onClick.AddListener(() => ChoosePicture(index));
        }
    }

    private void ChoosePicture(int indexOfPicture)
    {
        MenuColoringManagement.instance.INDEX_OF_CHOSE_PICTURE = indexOfPicture;
        SceneManager.LoadScene(SceneName.ColoringGame.ToString());
    }
}
