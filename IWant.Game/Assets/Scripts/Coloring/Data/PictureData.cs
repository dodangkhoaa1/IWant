using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Artwork", menuName = "Scriptable Objects/Artwork")]

public class PictureData : ScriptableObject
{
    public string EnglishName;
    public string VietnameseName;
    public Category CategoryName;
    public GameObject Prefab;
    public Sprite Sprite;
}
