using System.Collections;
using System.Collections.Generic;
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

    private void HandleRecommendationLoaded(Customer customer)
    {
        if (customer.Equals(this))
        {
            status = Status.Running;
            reWanted.SetActive(false);
            question.SetActive(true);
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
