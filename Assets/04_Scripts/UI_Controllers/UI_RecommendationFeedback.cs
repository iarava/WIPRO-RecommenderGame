using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_RecommendationFeedback : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI correctAnswer;
    [SerializeField]
    private TextMeshProUGUI feedback;


    private Image _feedbackImage;
    private TextMeshProUGUI _correctAnswer;
    private TextMeshProUGUI _feedback;

    private void Awake()
    {
        RecommendationManager.Instance.ShowFeedback += showFeedback;
        _feedbackImage = GetComponentInChildren<ImageCorrectRecommendation>().gameObject.GetComponent<Image>();
        _correctAnswer = correctAnswer;
        _feedback = feedback;
    }

    private void showFeedback(DataRecommendation recommendation)
    {
        _feedbackImage.sprite = recommendation.ImageFeedback;
        _correctAnswer.text = recommendation.TextCorrectAnswer;
        _feedback.text = recommendation.TextFeedback;
    }

    private void OnDestroy()
    {
        RecommendationManager.Instance.ShowFeedback -= showFeedback;
    }
}
