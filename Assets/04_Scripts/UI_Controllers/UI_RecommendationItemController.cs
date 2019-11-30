using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RecommendationItemController : MonoBehaviour
{
    private UI_RecommendationItem[] recommendationItems;
    
    private void OnEnable()
    {
        // Init Recommendation Items
        recommendationItems = GetComponentsInChildren<UI_RecommendationItem>();
        RecommendationManager.Instance.NewRecommendationLoaded += newRecommendationOpened;
    }

    private void newRecommendationOpened(Customer customer, DataRecommendation dataItems)
    {
        setRecommendationItems(dataItems.PossibleSelections);
        Debug.Log(dataItems.name);
    }

    public void setRecommendationItems(RecommendationItem[] dataItems)
    {
        if(dataItems.Length != recommendationItems.Length)
        {
            Debug.LogError("Given dataItemsList does not match the size of the recommendationItemsList");
        }

        for(int i = 0; i < dataItems.Length; i++)
        {
            Image image = recommendationItems[i].GetComponentInChildren<ImageItem>().gameObject.GetComponent<Image>();
            image.sprite = dataItems[i].RecommendationObject.ImageItem;

            Text text = recommendationItems[i].GetComponentInChildren<TextItem>().gameObject.GetComponent<Text>();
            text.text = dataItems[i].RecommendationObject.NameItem;

            recommendationItems[i].IsCorrectItem = dataItems[i].correctAnswer;
            
        }
        
    }

    private void OnDisable()
    {
        RecommendationManager.Instance.NewRecommendationLoaded -= newRecommendationOpened;
    }
}
