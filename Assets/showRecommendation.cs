using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showRecommendation : MonoBehaviour
{
    UI_RecommendationFeedback recommendationFeedback;
    UI_MethodeController methodeController;
    // Start is called before the first frame update
    private void Awake()
    {
        RecommendationManager.Instance.ShowRecommendation += handleShowRecommendation;
        RecommendationManager.Instance.BeforeShowFeedback += handleBeforeShowFeedback;

        recommendationFeedback = GetComponentInChildren<UI_RecommendationFeedback>();
        methodeController = GetComponentInChildren<UI_MethodeController>();

        gameObject.SetActive(false);
    }

    private void handleShowRecommendation(bool active)
    {
        gameObject.SetActive(active);

        if (active)
        {
            methodeController.gameObject.SetActive(true);
            recommendationFeedback.gameObject.SetActive(false);
        }
    }
    private void handleBeforeShowFeedback()
    {
        recommendationFeedback.gameObject.SetActive(true);
        methodeController.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        RecommendationManager.Instance.ShowRecommendation -= handleShowRecommendation;
        RecommendationManager.Instance.BeforeShowFeedback -= handleBeforeShowFeedback;
    }
}
