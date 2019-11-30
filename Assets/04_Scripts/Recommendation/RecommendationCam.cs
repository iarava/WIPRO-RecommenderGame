using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecommendationCam : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera Vcam;

    private void Awake()
    {
        RecommendationManager.Instance.NewRecommendationLoaded += HandleRecommendationLoaded;
        RecommendationManager.Instance.RecommendationFinished += HandleRecommendationFinished;
    }

    private void HandleRecommendationLoaded(Customer customer, DataRecommendation recommendation)
    {
        Vcam.Priority = 2;
    }

    private void HandleRecommendationFinished(Customer customer)
    {
        Vcam.Priority = 0;
    }
    
    private void OnDestroy()
    {
        RecommendationManager.Instance.NewRecommendationLoaded -= HandleRecommendationLoaded;
        RecommendationManager.Instance.RecommendationFinished -= HandleRecommendationFinished;
    }
}
