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

    private void OnDestroy()
    {
        StoryManager.Instance.DisplayDialogue -= handleDisplaySentence;
    }
}
