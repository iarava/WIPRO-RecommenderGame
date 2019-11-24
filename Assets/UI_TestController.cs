using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TestController : MonoBehaviour
{
    public void onEinfuehrungFinished()
    {
        LevelManager.EinfuehrungFinished();
    }
    public void onLevelFinished()
    {
        LevelManager.LevelFinished();
    }
}
