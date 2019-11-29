using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RecommendationPool", menuName = "DataRecommendationPool")]
public class DataRecommendationPool : ScriptableObject
{
    [SerializeField]
    private RecommendationPool[] RecommendationPool;
    
    private int currentPool;
}
