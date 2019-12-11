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
            CorrectRecommendation();
        }
        else
        {
            WrongRecommendation();
        }
    }

    private void WrongRecommendation()
    {
        BeforeShowFeedback();
        gameLoop.GetLevelDefinition().RecommendationPool.previousDifficulty();
        ShowFeedback(recommendation);
    }

    private void CorrectRecommendation()
    {
        gameLoop.AddScore();
        gameLoop.GetLevelDefinition().RecommendationPool.nextDifficulty();
        finishRecommendation();
    }

    public void finishRecommendation()
    {
        ShowRecommendation(false);
        RecommendationFinished(currentCustomer);
    }
}
