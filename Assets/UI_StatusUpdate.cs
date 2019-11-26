using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_StatusUpdate : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textLevel;

    private string levelName;

    // Start is called before the first frame update
    private void Awake()
    {
        LevelManager.Instance.newLevelLoaded += HandleNewLevelLoaded;
        Debug.Log("Add event New Level");
    }

    private void HandleNewLevelLoaded()
    {
        levelName = LevelManager.Instance.GetCurrentLevelName();
    }

    private void Update()
    {
        textLevel.text = string.Format("Level: {0}", levelName);
    }

    private void OnDestroy()
    {
        LevelManager.Instance.newLevelLoaded -= HandleNewLevelLoaded;
    }
}
