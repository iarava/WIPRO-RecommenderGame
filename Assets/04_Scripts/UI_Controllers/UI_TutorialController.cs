using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TutorialController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTitle;
    [SerializeField]
    private TextMeshProUGUI textDescription;
    [SerializeField]
    private Image imageTutorial;
        
    private void Awake()
    {
        StoryManager.Instance.DisplayTutorial += handleDisplayTutorial;
    }

    public void onStartLevel()
    {
        StoryManager.Instance.EndStorySequence();
    }

    private void handleDisplayTutorial(Tutorial tutorial)
    {
        textTitle.text = tutorial.TutorialTitel;
        textDescription.text = tutorial.Description;
        if(imageTutorial != null)
        {
            imageTutorial.sprite = tutorial.TutorialImage;
        }

    }

    private void onDestroy()
    {
        StoryManager.Instance.DisplayTutorial -= handleDisplayTutorial;
    }
}
