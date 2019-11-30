using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecommendationManager : MonoBehaviour
{
    public static RecommendationManager Instance { get; private set; }

    private int levelPool = 0; //ToDo: which Pool is requested (Association, Content-based, Collaborativ)

    private int countRecommendations;  //ToDo: is the counter for which Recommendation in Pool
    private int difficulty;  //ToDo: which difficulty of the Pool is requested (optional)

    private Customer currentCustomer;

    public event Action<Customer, DataRecommendation> NewRecommendationLoaded = delegate { };
    public event Action ShowFeedback = delegate { };
    public event Action<Customer> RecommendationFinished = delegate { };

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        LevelManager.Instance.newLevelLoaded += handleNewLoadedLevel;
    }

    private void handleNewLoadedLevel()
    {
        levelPool = LevelManager.Instance.GetCurrenLevelPool();

        countRecommendations = 0;
        difficulty = 0;
    }

    public void RequestRecommendation(Customer customer)
    {
        currentCustomer = customer;
        NewRecommendationLoaded(customer, new DataRecommendation());
    }

    public void checkRecommendation(bool correct)
    {
        if (correct)
            finishRecommendation();             //optional increas difficulty
        else
            ShowFeedback();
    }

    public void finishRecommendation()
    {
        //countRecommendations++;               //next Recommendation (check for max. Recommendations)
        RecommendationFinished(currentCustomer);
    }

    private void OnDestroy()
    {
        LevelManager.Instance.newLevelLoaded -= handleNewLoadedLevel;
    }
}
