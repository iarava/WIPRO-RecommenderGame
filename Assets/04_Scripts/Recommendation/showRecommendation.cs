using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showRecommendation : MonoBehaviour
{
    private UI_RecommendationFeedback recommendationFeedback;
    private UI_MethodeController methodeController;

    private UI_RecommendationItem[] recommendationItems;

    // Start is called before the first frame update
    private void Awake()
    {
        RecommendationManager.Instance.ShowRecommendation += handleShowRecommendation;
        RecommendationManager.Instance.WrongSelection += handleWrongSelection;

        recommendationFeedback = GetComponentInChildren<UI_RecommendationFeedback>();
        methodeController = GetComponentInChildren<UI_MethodeController>();

        recommendationItems = GetComponentsInChildren<UI_RecommendationItem>();

        gameObject.SetActive(false);
    }

    private void handleShowRecommendation(bool active)
    {
        gameObject.SetActive(active);

        if (active)
        {
            methodeController.gameObject.SetActive(true);
            recommendationFeedback.gameObject.SetActive(false);

            enableSelection(true);
        }
    }
    private void handleWrongSelection(Customer customer)
    {
        recommendationFeedback.gameObject.SetActive(true);
        methodeController.gameObject.SetActive(false);

        enableSelection(false);        
    }

    private void enableSelection(bool enable)
    {
        foreach (UI_RecommendationItem item in recommendationItems)
        {
            item.enabled = enable;
        }
    }

    private void OnDestroy()
    {
        RecommendationManager.Instance.ShowRecommendation -= handleShowRecommendation;
        RecommendationManager.Instance.WrongSelection -= handleWrongSelection;
    }
}
