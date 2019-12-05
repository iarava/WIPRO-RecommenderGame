using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        StoryManager.Instance.StartDialogue(dialogue);
    }
}
