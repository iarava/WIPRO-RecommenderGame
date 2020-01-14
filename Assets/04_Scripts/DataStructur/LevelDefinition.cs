using UnityEngine;

[CreateAssetMenu(fileName = "New LevelDefinition", menuName = "LevelDefinition")]
public class LevelDefinition : ScriptableObject
{
    [SerializeField]
    private float levelTime = 180.0f;
    [SerializeField]
    private string levelName;
    [SerializeField]
    private StoryDefinition storySequence;
    [SerializeField]
    private DataRecommendationPool recommendationPool;


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

    public StoryDefinition StorySequence
    {
        get
        {
            return storySequence;
        }
    }

    public DataRecommendationPool RecommendationPool
    {
        get
        {
            return recommendationPool;
        }
    }
}
