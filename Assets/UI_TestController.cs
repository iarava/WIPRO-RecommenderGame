using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TestController : MonoBehaviour
{
    public void onEinfuehrungFinished()
    {
        LevelManager.Instance.EinfuehrungFinished();
    }
    public void onLevelFinished()
    {
        LevelManager.Instance.LevelFinished();
    }
}
