using UnityEngine;

[CreateAssetMenu(fileName = "New RecommendationPool", menuName = "DataRecommendationPool")]
public class DataRecommendationPool : ScriptableObject
{
    [SerializeField]
    private RecommendationPool[] recommendationPools;
    
    private int currentPool;

    public void resetPool()
    {
        currentPool = 0;
    }

    public void nextDifficulty()
    {
        if(currentPool < recommendationPools.Length-1)
            currentPool++;
    }

    public void previousDifficulty()
    {
        if (currentPool > 0)
            currentPool--;
    }

    public RecommendationPool GetRecommendationPool()
    {
        return recommendationPools[currentPool];
    }
}
