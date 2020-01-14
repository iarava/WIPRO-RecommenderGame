using UnityEngine;

public class SoundCheckRecommendation : MonoBehaviour
{
    [SerializeField]
    private AudioManager.SoundType SoundWrongRecommendation;

    [SerializeField]
    private AudioManager.SoundType SoundCorrectRecommendation;

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
