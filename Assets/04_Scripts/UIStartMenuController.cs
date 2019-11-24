using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartMenuController : MonoBehaviour
{
    public void onStartPressed()
    {
        LevelManager.StartGame();
    }
}
