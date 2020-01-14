using TMPro;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public Status status { get; private set; }

    [SerializeField]
    private GameObject reWanted = null;
    [SerializeField]
    private GameObject question = null;

    // Start is called before the first frame update
    void Awake()
    {
        status = Status.Idle;

        RecommendationManager.Instance.NewRecommendationLoaded += HandleRecommendationLoaded;
        RecommendationManager.Instance.RecommendationFinished += HandleRecommendationFinished;
    }

    public void setSign()
    {
        status = Status.Waiting;
        reWanted.SetActive(true);
    }

    private void HandleRecommendationLoaded(Customer customer, DataRecommendation recommendation)
    {
        if (customer.Equals(this))
        {
            status = Status.Running;
            reWanted.SetActive(false);
            question.SetActive(true);
            question.GetComponentInChildren<UI_QuestionSpeechText>().gameObject.GetComponent<TextMeshProUGUI>().text = recommendation.Question; // setQuestionText(recommendation.Question);
        }
    }

    private void HandleRecommendationFinished(Customer customer)
    {
        if (customer.Equals(this))
        {
            status = Status.Idle;
            question.SetActive(false);
        }        
    }

    private void OnDestroy()
    {
        RecommendationManager.Instance.NewRecommendationLoaded -= HandleRecommendationLoaded;
        RecommendationManager.Instance.RecommendationFinished -= HandleRecommendationFinished;
    }
}
