using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recommendation", menuName = "DataRecommendation")]
public class DataRecommendation : ScriptableObject
{
    [SerializeField, TextArea(3, 20)]
    private string question;
    [SerializeField]
    private DataRecommendationItem[] possibleSelections;
    [SerializeField]
    private int correctSelection;
    [SerializeField]
    private Sprite imageMethode;
    [SerializeField]
    private Sprite imageFeedback;
    [SerializeField]
    private string textFeedback;
    [SerializeField]
    private string textCorrectAnswer;
}
