using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeLevel = 0.0f;
    private float startTimestamp;
    private bool timerRunning = false;
    
    public event Action<float> OnTimeChanged = delegate { };

    private void Awake()
    {
        LevelManager.Instance.newLevel += initializeTimer;
    }

    private void initializeTimer()
    { 
        timeLevel = LevelManager.Instance.GetCurrentLevelTime();
        Debug.Log(timeLevel);
        startTimestamp = Time.time;
        timerRunning = true;
    }

    private void Update()
    {
        if (timerRunning)
        {
            float actualTime = Time.time - startTimestamp;

            OnTimeChanged(actualTime);

            if (actualTime >= timeLevel)
            {
                timerRunning = false;
                Debug.Log("Stop Level");
                LevelManager.Instance.LevelTimeElapsed(); 
            }
        }
    }
       
    private void onDestroy()
    {
        LevelManager.Instance.newLevel -= initializeTimer;
    }
}
