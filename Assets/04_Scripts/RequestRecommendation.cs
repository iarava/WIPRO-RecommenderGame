using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestRecommendation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Customer customer = this.gameObject.GetComponent<Customer>();
        if(customer.status == Status.Waiting)
        {
            Debug.Log("Show Question");
            RecommendationManager.Instance.RequestRecommendation(customer);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Customer customer = this.gameObject.GetComponent<Customer>();
        if (customer.status == Status.Running)
        {
            Debug.Log("Question Anwserd");
            RecommendationManager.Instance.finishRecommendation();
        }
    }
}
