using UnityEngine;

[CreateAssetMenu(fileName = "New StoryDefinition", menuName = "StoryDefinition")]
public class StoryDefinition : ScriptableObject
{
    [SerializeField]
    private Dialogue Intro;
    [SerializeField]
    private Tutorial tutorial;
    [SerializeField]
    private Dialogue Outro;

    public Dialogue getDialogue(bool isIntro)
    {
        if (isIntro)
        {
            isIntro = false;
            return Intro;
        }
        else
        {
            isIntro = true;
            return Outro;
        }
    }

    public Tutorial Tutorial
    {
        get
        {
            return tutorial;
        }
    }
}
