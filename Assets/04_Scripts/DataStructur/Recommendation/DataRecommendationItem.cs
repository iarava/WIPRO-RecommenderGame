using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RecommendationItem", menuName = "DataRecommendationItem")]
public class DataRecommendationItem : ScriptableObject
{
    [SerializeField]
    private string nameItem;
    [SerializeField]
    private Sprite imageItem;

    public string NameItem
    {
        get
        {
            return nameItem;
        }
    }

    public Sprite ImageItem
    {
        get
        {
            return imageItem;
        }
    }
}
