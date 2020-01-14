using UnityEngine;

[System.Serializable]
public class Tutorial 
{
    public string TutorialTitel;
    [TextArea(8, 10)]
    public string Description;
    public Sprite TutorialImage;
}
