﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameLoop", menuName = "GameLoop")]
public class GameLoopDefinition : ScriptableObject
{
    [SerializeField]
    private LevelDefinition[] levels;

    private int currentLevel;
    private bool isIntro;
    private int score;

    public void resetGameLoop()
    {
        if(LevelCountReached())
            GetLevelDefinition().RecommendationPool.resetPool();

        currentLevel = 0;
        isIntro = true;
        score = 0;
    }

    public void NextLevel()
    {
        GetLevelDefinition().RecommendationPool.resetPool();
        currentLevel++;
        setTutorialState(true);
    }

    public void setTutorialState(bool needsIntro)
    {
        isIntro = needsIntro;
    }

    public bool GetIsIntro()
    {
        return isIntro;
    }

    public LevelDefinition GetLevelDefinition()
    {
        return levels[currentLevel];
    }

    public bool LevelCountReached()
    {
        return (currentLevel < levels.Length);
    }

    public void AddScore()
    {
        score += GetLevelDefinition().RecommendationPool.GetRecommendationPool().ScoreAmount;
    }

    public int GetScore()
    {
        return score;
    }
}
