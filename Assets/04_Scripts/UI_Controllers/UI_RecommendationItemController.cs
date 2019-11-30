using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RecommendationItemController : MonoBehaviour
{
    private RecommenderItem[] recommendationItems;

    private void Awake()
    {
        // Init Recommendation Items
        recommendationItems = GetComponentsInChildren<RecommenderItem>();
    }

    public void setRecommendationItems(DataItem[] dataItems)
    {
        if(dataItems.Length != recommendationItems.Length)
        {
            Debug.LogError("Given dataItemsList does not match the size of the recommendationItemsList");
        }

        for(int i = 0; i < dataItems.Length; i++)
        {
            Image image = recommendationItems[i].GetComponent<Image>();
            image.sprite = dataItems[i].ImageItem;

            Text text = recommendationItems[i].GetComponent<Text>();
            text.text = dataItems[i].NameItem;

            UI_RecommendationItem script = recommendationItems[i].GetComponent<UI_RecommendationItem>();
            script.IsCorrectItem = false; // Where do I get the value from?
            
        }
        
    }



}
