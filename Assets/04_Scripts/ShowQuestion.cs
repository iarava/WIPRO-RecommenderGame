using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowQuestion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Customer customer = this.gameObject.GetComponent<Customer>();
        if(customer.status == Status.Waiting)
        {
            Debug.Log("Show Question");
            customer.loadRecommendation();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Customer customer = this.gameObject.GetComponent<Customer>();
        if (customer.status == Status.Running)
        {
            Debug.Log("Question Anwserd");
            customer.leavePlayer();
        }
    }
}
