using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Question : MonoBehaviour
{
    private void Awake()
    {
        RecommendationManager.Instance.NewRecommendationLoaded += newRecommendationLoaded;
    }

    private void newRecommendationLoaded(Customer customer, DataRecommendation recommendation)
    {
        //GetComponentInChildren<>().gameObject.GetComponent<Text>().text = recommendation.Question;
    }

    private void showFeedback(DataRecommendation recommendation)
    {
        GetComponentInChildren<ImageCorrectRecommendation>().gameObject.GetComponent<Image>().sprite = recommendation.ImageFeedback;
        GetComponentInChildren<FeedbackCorrectAnswer>().gameObject.GetComponent<Text>().text = recommendation.TextFeedback;
    }


    private void OnDisable()
    {
        RecommendationManager.Instance.NewRecommendationLoaded -= newRecommendationLoaded;
    }
}
