using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecommendationManager : MonoBehaviour
{
    public static RecommendationManager Instance { get; private set; }

    [SerializeField]
    private GameLoopDefinition gameLoop = null;

    private Customer currentCustomer;
    private DataRecommendation recommendation;
    private int countCorrectAnswers = 0;

    public event Action<bool> ShowRecommendation = delegate { };
    public event Action<Customer, DataRecommendation> NewRecommendationLoaded = delegate { };
    public event Action BeforeShowFeedback = delegate { };
    public event Action<DataRecommendation> ShowFeedback = delegate { };
    public event Action<Customer> RecommendationFinished = delegate { };

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void RequestRecommendation(Customer customer)
    {
        ShowRecommendation(true);
        recommendation = gameLoop.GetLevelDefinition().RecommendationPool.GetRecommendationPool().GetRecommendation();
        currentCustomer = customer;
        NewRecommendationLoaded(customer, recommendation);
    }

    public void checkRecommendation(bool correct)
    {
        if (correct)
        {
            UpdateStates();
            finishRecommendation();
        }
        else
        {
            BeforeShowFeedback();
            ShowFeedback(recommendation); // TODO: Set DataRecommendation
        }
    }

    private void UpdateStates()
    {
        gameLoop.AddScore();
        countCorrectAnswers = 0;
        if (countCorrectAnswers >= 3)
        {
            gameLoop.GetLevelDefinition().RecommendationPool.nextDifficulty();
            countCorrectAnswers = 0;
        }
    }

    public void finishRecommendation()
    {
        ShowRecommendation(false);
        RecommendationFinished(currentCustomer);
    }
}
