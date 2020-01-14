using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "DataItem")]
public class DataItem : ScriptableObject
{
    [SerializeField]
    private string nameItem;
    [SerializeField]
    private Sprite imageItem;

    public string NameItem
    {
        get
        {
            return nameItem;
        }
    }

    public Sprite ImageItem
    {
        get
        {
            return imageItem;
        }
    }
}
