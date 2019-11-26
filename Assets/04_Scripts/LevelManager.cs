using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public static int level { get; private set; }

    public event Action newLevelLoaded = delegate { };

    [SerializeField]
    private LevelDefinition[] levels = null;

    private void Awake()
    {
        Instance = this;

        SceneManager.sceneLoaded += HandleSceneLoaded;
    }

    public float GetCurrentLevelTime()
    {
        return levels[level].LevelTime;
    }

    public string GetCurrentLevelName()
    {
        return levels[level].LevelName;
    }

    public void StartGame()
    {
        level = 0;
        StartEinfuehrung();
    }

    private void StartEinfuehrung()
    {
        SceneManager.LoadScene(1);
    }

    public void EinfuehrungFinished()
    {
        SceneManager.LoadScene(2);
        newLevelLoaded();
        Debug.Log("New Level");
    }

    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
            newLevelLoaded();
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
            StartEinfuehrung();
        }
        else
        {
            Debug.Log("Game Finished");
        }
    }
}
