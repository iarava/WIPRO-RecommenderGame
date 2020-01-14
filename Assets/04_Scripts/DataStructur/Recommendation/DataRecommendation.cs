using UnityEngine;

[CreateAssetMenu(fileName = "New Recommendation", menuName = "DataRecommendation")]
public class DataRecommendation : ScriptableObject
{
    [SerializeField, TextArea(3, 20)]
    private string question;
    [SerializeField]
    private RecommendationItem[] possibleSelections;
    [SerializeField]
    private Sprite imageMethode;
    [SerializeField]
    private Sprite imageFeedback;
    [SerializeField]
    private string textFeedback;
    [SerializeField]
    private string textCorrectAnswer;

    public string Question
    {
        get
        {
            return question;
        }
    }

    public RecommendationItem[] PossibleSelections
    {
        get
        {
            return possibleSelections;
        }
    }

    public Sprite ImageMethode
    {
        get
        {
            return imageMethode;
        }
    }

    public Sprite ImageFeedback
    {
        get
        {
            return imageFeedback;
        }
    }

    public string TextFeedback
    {
        get
        {
            return textFeedback;
        }
    }

    public string TextCorrectAnswer
    {
        get
        {
            return textCorrectAnswer;
        }
    }
}
