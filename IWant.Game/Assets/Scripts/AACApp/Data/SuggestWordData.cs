using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "WordData", menuName = "Scriptable Objects/Word Data", order = 0)]
public class SuggestWordData : ScriptableObject
{
    public List<int> aacWordsId;
    public Sprite groupWordSprite;
    public string VietnameseText;
    public string EnglishText;
    public int nextCategoryId;
}
