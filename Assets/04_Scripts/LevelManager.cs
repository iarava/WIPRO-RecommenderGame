using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public static int level { get; private set; }

    public event Action newLevel = delegate { };

    [SerializeField]
    private LevelDefinition[] levels = null;

    public float GetCurrentLevelTime()
    {
        return levels[level].LevelTime;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        level = 0;
        StartEinfuehrng();
    }

    private void StartEinfuehrng()
    {
        SceneManager.LoadScene(1);
    }

    public void EinfuehrungFinished()
    {
        newLevel();
        SceneManager.LoadScene(2);
    }

    public void LevelTimeElapsed()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Level finished");
    }

    public void LevelFinished()
    {
        level++;
        if(level < levels.Length)
        {
            Debug.Log("Next Level");
            StartEinfuehrng();
        }
        else
        {
            Debug.Log("Game Finished");
        }
    }
}
