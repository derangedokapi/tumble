using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelConfigSO", order = 1)]
public class LevelConfigSO : ScriptableObject
{
    public string levelName;
    public string levelDescription;
    
    public float levelDuration;

    public float fallSpeed = 15f;

    public GameObject[] availableEnemies;
    public string[] levelMessages;
}