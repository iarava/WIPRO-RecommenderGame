using UnityEngine;

[System.Serializable]
public class RecommendationPool
{
    public DataRecommendation[] RecommendationCataloge;
    public int ScoreAmount;

    public DataRecommendation GetRecommendation()
    {
        int index = Random.Range(0, RecommendationCataloge.Length);
        return RecommendationCataloge[index];
    }
}
