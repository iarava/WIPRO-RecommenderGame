using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_EndScoreController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textScore;

    private void Awake()
    {
        int score = LevelManager.Instance.GetScore();
        textScore.text = string.Format("{0}", score);
    }

}
