using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartMenuController : MonoBehaviour
{
    public void onStartPressed()
    {
        LevelManager.Instance.StartGame();
    }

    public void onQuitPressed()
    {
        Application.Quit();
    }
}
