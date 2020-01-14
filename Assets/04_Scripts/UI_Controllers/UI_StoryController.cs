using UnityEngine;
using TMPro;

public class UI_StoryController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textSentence;

    private void Awake()
    {
        StoryManager.Instance.DisplayDialogue += handleDisplaySentence;
    }

    public void onNextSentence()
    {
        StoryManager.Instance.DisplayNextSentence();
    }

    private void handleDisplaySentence(string sentence)
    {
        textSentence.text = sentence;
    }

    private void onDestroy()
    {
        StoryManager.Instance.DisplayDialogue -= handleDisplaySentence;
    }
}
