using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCheckRecommendation : MonoBehaviour
{
    [SerializeField]
    private SoundData SoundWrongRecommendation;

    [SerializeField]
    private SoundData SoundCorrectRecommendation;

    private void Awake()
    {
            RecommendationManager.Instance.WrongSelection += handleWrongSelection;
            RecommendationManager.Instance.CorrectSelection += handleCorrectSelection;
    }

    private void handleWrongSelection(Customer currentCustomer)
    {
        if (gameObject.GetComponent<Customer>().Equals(currentCustomer))
            AudioManager.Instance.Play(SoundWrongRecommendation);
    }

    private void handleCorrectSelection(Customer currentCustomer)
    {
        if(gameObject.GetComponent<Customer>().Equals(currentCustomer))
            AudioManager.Instance.Play(SoundCorrectRecommendation);
    }

    private void OnDestroy()
    {
        RecommendationManager.Instance.WrongSelection -= handleWrongSelection;
        RecommendationManager.Instance.CorrectSelection -= handleCorrectSelection;
    }
}
