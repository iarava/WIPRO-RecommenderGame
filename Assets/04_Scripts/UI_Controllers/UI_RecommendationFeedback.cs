using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RecommendationFeedback : MonoBehaviour
{
    private void Awake()
    {
        RecommendationManager.Instance.ShowFeedback += showFeedback;
    }

    private void showFeedback(DataRecommendation recommendation)
    {
        GetComponentInChildren<ImageCorrectRecommendation>().gameObject.GetComponent<Image>().sprite = recommendation.ImageFeedback;
        GetComponentInChildren<FeedbackCorrectAnswer>().gameObject.GetComponent<Text>().text = recommendation.TextCorrectAnswer;
    }

    private void OnDisable()
    {
        RecommendationManager.Instance.ShowFeedback -= showFeedback;
    }
}
