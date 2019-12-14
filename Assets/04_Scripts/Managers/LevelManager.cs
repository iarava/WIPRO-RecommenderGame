using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField]
    private GameLoopDefinition gameLoop = null;

    [SerializeField]
    private SoundData gameSound;

    public event Action stopGame = delegate { };
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
        return gameLoop.GetLevelDefinition().LevelTime;
    }

    public string GetCurrentLevelName()
    {
        return gameLoop.GetLevelDefinition().LevelName;
    }

    public int GetScore()
    {
        return gameLoop.GetScore();
    }

    public void StartGame()
    {
        gameLoop.resetGameLoop();
        StartEinfuehrung();
        AudioManager.Instance.Play(gameSound);
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
        gameLoop.NextLevel();
        if (gameLoop.LevelCountReached())
        {
            Debug.Log("Next Level");
            StartEinfuehrung();
        }
        else
        {
            Debug.Log("Game Finished");
            AudioManager.Instance.Stop(gameSound);
            SceneManager.LoadScene(4);
        }
    }

    public void StopGame()
    {
        gameLoop.resetGameLoop();
        AudioManager.Instance.Stop(gameSound);
        stopGame();
        SceneManager.LoadScene(0);
    }
}
