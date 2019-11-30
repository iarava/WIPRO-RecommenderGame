using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showRecommendation : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        RecommendationManager.Instance.ShowRecommendation += handleShowRecommendation;

        gameObject.SetActive(false);
    }

    private void handleShowRecommendation(bool active)
    {
        gameObject.SetActive(active);
    }

    private void OnDestroy()
    {
        RecommendationManager.Instance.ShowRecommendation -= handleShowRecommendation;
    }
}
