using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField]
    private LevelDefinition[] levels = null;

    public int level = 0;

    public event Action newLevelLoaded = delegate { };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

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

    public int GetCurrenLevelPool()
    {
        //ToDo Implementation needed according DataStructur
        return 0;
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

    public void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 1)
            EinfuehrungFinished();
        else
            LevelFinished();
    }

    private void EinfuehrungFinished()
    {
        SceneManager.LoadScene(2);
    }

    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {
            newLevelLoaded();
            Debug.Log("New Level");
        }            
    }

    public void LevelTimeElapsed()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Level finished");
    }

    private void LevelFinished()
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
