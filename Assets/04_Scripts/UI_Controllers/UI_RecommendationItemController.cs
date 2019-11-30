using System;
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
        RecommendationManager.Instance.NewRecommendationLoaded += newRecommendationOpened;
    }

    private void newRecommendationOpened(Customer customer, DataRecommendation dataItems)
    {
        setRecommendationItems(dataItems.PossibleSelections);
    }

    public void setRecommendationItems(RecommendationItem[] dataItems)
    {
        if(dataItems.Length != recommendationItems.Length)
        {
            Debug.LogError("Given dataItemsList does not match the size of the recommendationItemsList");
        }

        for(int i = 0; i < dataItems.Length; i++)
        {
            Image image = recommendationItems[i].GetComponent<Image>();
            image.sprite = dataItems[i].RecommendationObject.ImageItem;

            Text text = recommendationItems[i].GetComponent<Text>();
            text.text = dataItems[i].RecommendationObject.NameItem;

            UI_RecommendationItem script = recommendationItems[i].GetComponent<UI_RecommendationItem>();
            script.IsCorrectItem = dataItems[i].correctAnswer;
            
        }
        
    }



}
