using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeElements : MonoBehaviour
{
    private StoryElement[] storyElements;
    private TutorialElement[] tutorialElements;

    private void Start()
    {
        storyElements = FindObjectsOfType<StoryElement>();
        tutorialElements = FindObjectsOfType<TutorialElement>();

        StoryManager.Instance.DisplayTutorial += handleDisplayTutorial;

        SetStoryElements(true);
    }

    private void handleDisplayTutorial(Tutorial tutorial)
    {
        SetStoryElements(false);
    }

    private void SetStoryElements(bool setActive)
    {
        foreach (StoryElement storyElement in storyElements)
        {
            storyElement.gameObject.SetActive(setActive);
        }

        foreach (TutorialElement tutorialElement in tutorialElements)
        {
            tutorialElement.gameObject.SetActive(!setActive);
        }
    }

    private void OnDestroy()
    {
        StoryManager.Instance.DisplayTutorial -= handleDisplayTutorial;
    }
}
