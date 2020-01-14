using Cinemachine;
using UnityEngine;

public class RecommendationCam : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera Vcam;

    private Transform defaultLookAtPosition;

    private void Awake()
    {
        RecommendationManager.Instance.NewRecommendationLoaded += HandleRecommendationLoaded;
        RecommendationManager.Instance.RecommendationFinished += HandleRecommendationFinished;
    }

    private void HandleRecommendationLoaded(Customer customer, DataRecommendation recommendation)
    {
        defaultLookAtPosition = Vcam.Follow;
        Vcam.Follow = customer.transform;
        Vcam.Priority = 2;
    }

    private void HandleRecommendationFinished(Customer customer)
    {
        Vcam.Follow = defaultLookAtPosition;
        Vcam.Priority = 0;
    }
    
    private void OnDestroy()
    {
        RecommendationManager.Instance.NewRecommendationLoaded -= HandleRecommendationLoaded;
        RecommendationManager.Instance.RecommendationFinished -= HandleRecommendationFinished;
    }
}
