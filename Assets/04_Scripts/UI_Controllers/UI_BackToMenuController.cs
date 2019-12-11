using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_BackToMenuController : MonoBehaviour
{
    public void OnBackToMenu()
    {
        Debug.Log("Back to Menu");
        SceneManager.LoadScene(0);
    }
}
