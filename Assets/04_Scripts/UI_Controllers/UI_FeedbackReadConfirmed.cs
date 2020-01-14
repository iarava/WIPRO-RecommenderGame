using UnityEngine;

public class UI_FeedbackReadConfirmed : MonoBehaviour
{
    public void onFeedbackReadClicked()
    {
        RecommendationManager.Instance.finishRecommendation();
    }
}
