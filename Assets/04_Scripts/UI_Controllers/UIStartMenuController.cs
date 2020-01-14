using UnityEngine;

public class UIStartMenuController : MonoBehaviour
{
    [SerializeField]
    private RectTransform creditsPopup;
    private GameObject creditsPopupObject;

    private void Awake()
    {
        creditsPopupObject = creditsPopup.gameObject;
        creditsPopupObject.SetActive(false);
    }

    public void onStartPressed()
    {
        LevelManager.Instance.StartGame();
    }

    public void onCreditsPressed()
    {
        creditsPopupObject.SetActive(true);
    }

    public void onCreditsClosePressed()
    {
        creditsPopupObject.SetActive(false);
    }

    public void onQuitPressed()
    {
        Application.Quit();
    }
}
