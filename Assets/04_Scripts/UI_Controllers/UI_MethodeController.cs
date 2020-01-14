using UnityEngine;
using UnityEngine.UI;

public class UI_MethodeController : MonoBehaviour
{
    [SerializeField]
    Image methodImage;

    public void OnEnable()
    {
        RecommendationManager.Instance.NewRecommendationLoaded += handlerRecommendationLoaded;
    }

    private void handlerRecommendationLoaded(Customer customer, DataRecommendation recommendation)
    {
        methodImage.sprite = recommendation.ImageMethode;
    }

    public void OnDisable()
    {
        RecommendationManager.Instance.NewRecommendationLoaded -= handlerRecommendationLoaded;
    }
}
