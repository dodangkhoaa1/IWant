using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BrushData", menuName ="Scriptable Objects/Brush Data", order = 0)]
public class BrushData : ScriptableObject
{
    //Texture
    [SerializeField] private Texture2D texture;
    public Texture2D Texture => texture;

    //Hardness
    [SerializeField] [Range(0f,1f)] private float hardness;
    public float Hardness => hardness;
}
