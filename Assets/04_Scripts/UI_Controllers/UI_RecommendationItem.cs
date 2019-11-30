using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_RecommendationItem : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler, IEndDragHandler
{
    private RecommenderItem[] canvas;

    [SerializeField]
    private Vector2 center = new Vector2(770, 510);
    [SerializeField]
    private float horizontalLength = 200f;
    [SerializeField]
    private float verticalLength = 200f;

    private bool isCorrectItem = false;

    private RecommendationManager recommendationManager;
    
    public bool IsCorrectItem { get; set; }

    private void Awake()
    {
        canvas = GetComponents<RecommenderItem>();
        recommendationManager = RecommendationManager.Instance;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GridLayoutGroup grid = GetComponentInParent<GridLayoutGroup>();
        if (grid != null)
        {
            grid.enabled = false;
            Debug.Log("Disabled Grid Layout");
        }
        //canvas = Color.green;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GridLayoutGroup grid = GetComponentInParent<GridLayoutGroup>();
        if (isInRecommendationField(eventData.position))
        {
            Debug.Log("Item placed, Grid still disabled");
            recommendationManager.checkRecommendation(true);
        }
        else
        {
            Debug.Log("Not in the correct postion, Grid Layout enabled again");
            grid.enabled = true;
            recommendationManager.checkRecommendation(false);
        }
        Debug.Log(eventData.position.ToString());
        //canvas = Color.white;
    }

    public void OnDrop(PointerEventData eventData)
    {
    }

    private bool isInRecommendationField(Vector2 targetPos)
    {
        float minX = center.x - horizontalLength / 2;
        float maxX = center.x + horizontalLength / 2;
        float minY = center.y - verticalLength / 2;
        float maxY = center.y + verticalLength / 2;

        Debug.Log(string.Format("X: {0} {1} ; Y: {2} {3}", minX, maxX, minY, maxY));
        
        if(targetPos.x > minX && targetPos.y < maxX &&
            targetPos.y > minY && targetPos.y < maxY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
