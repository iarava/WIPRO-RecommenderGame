using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public static int level { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public static void StartGame()
    {
        level = 0;
        StartEinfuehrng();
    }

    private static void StartEinfuehrng()
    {
        SceneManager.LoadScene(1);
    }

    public static void EinfuehrungFinished()
    {
        SceneManager.LoadScene(2);
    }

    public static void LevelTimeElapsed()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Level finished");
    }

    public static void LevelFinished()
    {
        level++;
        if(level < 3)
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
