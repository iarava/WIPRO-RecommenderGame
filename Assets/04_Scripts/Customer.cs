using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public Status status { get; private set; }

    [SerializeField]
    private GameObject reWanted = null;
    [SerializeField]
    private GameObject question = null;

    // Start is called before the first frame update
    void Start()
    {
        status = Status.Idle;
    }

    public void setSign()
    {
        status = Status.Waiting;
        reWanted.SetActive(true);
    }

    public void loadRecommendation()
    {
        status = Status.Running;
        reWanted.SetActive(false);
        question.SetActive(true);
    }

    public void leavePlayer()
    {
        status = Status.Idle;
        question.SetActive(false);
    }
}
