using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{

    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.1f;
    [SerializeField]
    private Timer timer;

    private float timeLevel;

    // Start is called before the first frame update
    private void Awake()
    {
        timer.OnTimeSet += HandleTimeSet;
        timer.OnTimeChanged += HandleTimeChanged;
    }

    private void HandleTimeSet(float time)
    {
        timeLevel = time;
        HandleTimeChanged(0);
    }

    private void HandleTimeChanged(float time)
    {
        float currentTime = (timeLevel - time) / timeLevel;
        StartCoroutine(changeToTime(currentTime));
    }

    private IEnumerator changeToTime(float time)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;
        
        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            float amount = Mathf.Lerp(preChangePct, time, elapsed / updateSpeedSeconds);
            foregroundImage.fillAmount = amount;
            yield return null;
        }
        foregroundImage.fillAmount = time;
    }

    private void OnDestroy()
    {
        timer.OnTimeSet -= HandleTimeSet;
        timer.OnTimeChanged -= HandleTimeChanged;
    }
}
