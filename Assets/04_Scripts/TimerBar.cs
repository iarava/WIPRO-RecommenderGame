using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;

    private Timer timer;
    private float timeLevel;

    // Start is called before the first frame update
    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        timer.OnTimeChanged += HandleTimeChanged;
        InitializeTimeLevel();
    }

    private void InitializeTimeLevel()
    {
        timeLevel = LevelManager.Instance.GetCurrentLevelTime();
        HandleTimeChanged(0);
    }

    private void HandleTimeChanged(float time)
    {
        float currentTime = (timeLevel - time) / timeLevel;
        foregroundImage.fillAmount = currentTime; ;
    }

    private void OnDestroy()
    {
        timer.OnTimeChanged -= HandleTimeChanged;
    }
}
