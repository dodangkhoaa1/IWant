using UnityEngine;
[CreateAssetMenu(fileName = "Level Data", menuName = "Scriptable Object/Level Data", order = 1)]
public class LevelDataSO : ScriptableObject
{
    [Header(" Data ")]
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private int requiredHighscore;

    public GameObject GetLevel() => levelPrefab;

    public int GetRequiredHighscore() => requiredHighscore;
}
