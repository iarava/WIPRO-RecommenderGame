using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelDefinition", menuName = "LevelDefinition")]
public class LevelDefinition : ScriptableObject
{
    [SerializeField]
    private float levelTime = 180.0f;

    public float LevelTime
    {
        get
        {
            return levelTime;
        }
    }
}
