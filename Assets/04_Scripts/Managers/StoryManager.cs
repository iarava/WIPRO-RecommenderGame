using System;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance { get; private set; }

    private Queue<string> sentences;

    private Dialogue currentDialogue;
    private bool isIntro;

    [SerializeField]
    private GameLoopDefinition gameLoop;

    private StoryDefinition storySequence;

    public event Action<string> DisplayDialogue = delegate { };
    public event Action<Tutorial> DisplayTutorial = delegate { };

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        storySequence = gameLoop.GetLevelDefinition().StorySequence;
        currentDialogue = storySequence.getDialogue(gameLoop.GetIsIntro());
        sentences.Clear();

        foreach(string sentence in currentDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        DisplayDialogue(sentence);
    }

    void EndDialogue()
    {
        bool isIntro = gameLoop.GetIsIntro();
        if (isIntro)
            showTutorial();
        else
            EndStorySequence();

        gameLoop.setTutorialState(!isIntro);
    }

    private void showTutorial()
    {
        DisplayTutorial(storySequence.Tutorial);
        Debug.Log("Display Tutorial");
    }

    public void EndStorySequence()
    {
        LevelManager.Instance.LoadNextScene();
    }
}
