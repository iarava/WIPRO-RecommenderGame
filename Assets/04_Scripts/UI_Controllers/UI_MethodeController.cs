using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MethodeController : MonoBehaviour
{
    public void Awake()
    {
        RecommendationManager.Instance.NewRecommendationLoaded += handlerRecommendationLoaded;
    }

    private void handlerRecommendationLoaded(Customer customer, DataRecommendation recommendation)
    {
        //GetComponentInChildren<Text>().text = recommendation;
        GetComponentInChildren<Image>().sprite = recommendation.ImageMethode;
    }

    public void OnDestroy()
    {
        RecommendationManager.Instance.NewRecommendationLoaded -= handlerRecommendationLoaded;
    }
}
