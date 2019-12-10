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
        GetComponentInChildren<UI_QuestionSpeechText>().gameObject.GetComponent<TextMesh>().text = recommendation.Question;
    }


    private void OnDisable()
    {
        RecommendationManager.Instance.NewRecommendationLoaded -= newRecommendationLoaded;
    }

    public void setQuestionText(string question)
    {
        //UI_QuestionSpeechText obj = GetComponentInChildren<UI_QuestionSpeechText>();
        //obj.gameObject.GetComponent<TextMesh>().text = question;
    }
}
