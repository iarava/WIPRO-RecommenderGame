using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelDefinition", menuName = "LevelDefinition")]
public class LevelDefinition : ScriptableObject
{
    [SerializeField]
    private float levelTime = 180.0f;
    [SerializeField]
    private string levelName;

    public float LevelTime
    {
        get
        {
            return levelTime;
        }
    }

    public string LevelName
    {
        get
        {
            return levelName;
        }
    }
}
