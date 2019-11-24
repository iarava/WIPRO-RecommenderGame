using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timeLevel = 15.0f;
    [SerializeField]
    private float timeUpdate = 1.0f;

    private float timeNextUpdate;
    private float lastTimestamp;
    private bool timerRunning = false;

    private void Awake()
    {
        lastTimestamp = Time.time;
        timeNextUpdate = timeUpdate;
        timerRunning = true;
    }

    private void Update()
    {
        if (timerRunning)
        {
            if (Time.time - lastTimestamp >= timeUpdate)
            {
                timeUpdate += timeNextUpdate;
                Debug.Log("Update UI");
            }

            if (Time.time - lastTimestamp >= timeLevel)
            {
                timerRunning = false;
                Debug.Log("Stop Level");
                LevelManager.LevelFinished();
            }
        }
        
    }
}
