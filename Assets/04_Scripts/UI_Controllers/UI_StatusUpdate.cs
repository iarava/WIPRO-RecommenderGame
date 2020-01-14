using TMPro;
using UnityEngine;

public class UI_StatusUpdate : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textLevel;
    [SerializeField]
    private TextMeshProUGUI textScore;

    private string levelName;
    private int score;

    // Start is called before the first frame update
    private void Awake()
    {
        LevelManager.Instance.newLevelLoaded += HandleNewLevelLoaded;
        RecommendationManager.Instance.RecommendationFinished += handleRecommendationFinished;
        Debug.Log("Add event New Level");
    }

    private void HandleNewLevelLoaded()
    {
        levelName = LevelManager.Instance.GetCurrentLevelName();
        score = LevelManager.Instance.GetScore();
    }

    private void handleRecommendationFinished(Customer customer)
    {
        score = LevelManager.Instance.GetScore();
    }

    private void Update()
    {
        textLevel.text = string.Format("Level: {0}", levelName);
        textScore.text = string.Format("Score: {0}", score);
    }

    private void OnDestroy()
    {
        LevelManager.Instance.newLevelLoaded -= HandleNewLevelLoaded;
        RecommendationManager.Instance.RecommendationFinished += handleRecommendationFinished;
    }
}
