using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureManagement : MonoBehaviour
{
    [SerializeField] private Transform pictureContainer;

    private void Awake()
    {
        SpawnPicture();
        SetLandscapeOrientation();
    }

    private void SetLandscapeOrientation()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }

    private void SpawnPicture()
    {
        PictureData pictureGO = MenuColoringManagement.instance.PicturesToColor[MenuColoringManagement.instance.INDEX_OF_CHOSE_PICTURE];
        GameObject picturePrefab = pictureGO.Prefab;
        Vector3 spawnPosition = pictureContainer.position;
        GameObject spawnedPicture = Instantiate(picturePrefab, spawnPosition, Quaternion.identity, pictureContainer);
        spawnedPicture.tag = "PictureToColor";
    }


}
