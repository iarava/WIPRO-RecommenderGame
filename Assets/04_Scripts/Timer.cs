using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private LevelDefinition[] levels = null;

    private float timeLevel = 0.0f;
    [SerializeField]
    private float timeUpdate = 1.0f;

    private float timeNextUpdate;
    private float lastTimestamp;
    private bool timerRunning = false;

    public event Action<float> OnTimeSet = delegate { };
    public event Action<float> OnTimeChanged = delegate { };

    private void Awake()
    {
        timeLevel = levels[LevelManager.level].LevelTime;
        Debug.Log(timeLevel);
        lastTimestamp = Time.time;
        timeNextUpdate = timeUpdate;
        OnTimeSet(timeLevel);
        timerRunning = true;
    }

    private void Update()
    {
        if (timerRunning)
        {
            float actualTime = Time.time - lastTimestamp;
            if (actualTime >= timeUpdate)
            {
                timeUpdate += timeNextUpdate;
                Debug.Log("Update UI");
                OnTimeChanged(actualTime);
            }

            if (actualTime >= timeLevel)
            {
                timerRunning = false;
                Debug.Log("Stop Level");
                LevelManager.LevelTimeElapsed();
            }
        }
        
    }
}
