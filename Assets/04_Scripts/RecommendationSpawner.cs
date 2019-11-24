using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecommendationSpawner : MonoBehaviour
{
    [SerializeField]
    private Customer[] customers = null;

    [SerializeField]
    private float checkRecommendationCountdown = 3.0f;
    private float timerCheck = 0.0f;

    private List<Customer> freeCustomers = new List<Customer>();

    private bool firstSpawn = true;

    private void Start()
    {
        customers = GameObject.FindObjectsOfType<Customer>();
        if (customers.Length == 0)
        {
            Debug.LogError("No Customer is referenced.");
        }
        timerCheck = checkRecommendationCountdown;
    }

    private void Update()
    {
        timerCheck += Time.deltaTime;
        if(timerCheck >= checkRecommendationCountdown)
        {
            timerCheck = 0;
            if (isFreeRecommendation())
                StartCoroutine(SpawnRecommendation());
        }
    }

    private bool isFreeRecommendation()
    {
        Customer customer;
        freeCustomers.Clear();
        for (int i = 0; i < customers.Length; i++)
        {
            customer = customers[i];
            if(customer.status == Status.Idle)
                freeCustomers.Add(customer);
        }
        if(freeCustomers == null)
        {
            return false;
        }
        return true;
    }

    IEnumerator SpawnRecommendation()
    {
        Debug.Log("Start Spawning");
        int offset = Random.Range(1, freeCustomers.Count);
        int modulo = Random.Range(1, customers.Length);
        if (firstSpawn || (modulo == 1 & freeCustomers.Count == 1))
        {
            modulo = customers.Length;
            firstSpawn = false;
        }
        for (int i = 0; i < freeCustomers.Count; i++)
        {
            Spawn(freeCustomers[i], i+offset, modulo);
            yield return new WaitForSeconds(0.2f);
        }

        yield break;
    }

    private void Spawn(Customer customer, int index, int modulo)
    {
        bool spawnable = (index%modulo == 0);

        if (spawnable)
        {
            Debug.Log("Spawning Recommendations");
            customer.setSign();
        }
    }
}
