﻿using System;
using System.Collections;
using System.Collections.Generic;
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
        GetComponentInChildren<Text>().text = recommendation.name;
        methodImage.sprite = recommendation.ImageMethode;
    }

    public void OnDisable()
    {
        RecommendationManager.Instance.NewRecommendationLoaded -= handlerRecommendationLoaded;
    }
}
