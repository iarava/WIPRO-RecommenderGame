using UnityEngine;

public class UI_BackToMenuController : MonoBehaviour
{
    public void OnBackToMenu()
    {
        Debug.Log("Back to Menu - Stop Game");
        LevelManager.Instance.StopGame();
    }
}
