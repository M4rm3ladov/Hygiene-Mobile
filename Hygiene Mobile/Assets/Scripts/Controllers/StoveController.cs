using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveController : MonoBehaviour
{

    [SerializeField]
    HandWashManager handWashManager;
    [SerializeField]
    ConsumeFoodManager consumeFoodManager;
    private int _clicked = 0;
    private void OnMouseDown() {
        StoveClicked();           
    }
    private void StoveClicked(){
        if(_clicked == 0){
            CheckFoodCount();    
            return;
        }
        _clicked = 0;
        consumeFoodManager.Meal.SetActive(false);
        consumeFoodManager.ItemCountUI.SetActive(false);
        consumeFoodManager.Table.SetActive(false);
        consumeFoodManager.Left.SetActive(false);
        consumeFoodManager.Right.SetActive(false);
    }
    private void CheckFoodCount(){
        _clicked = 1;
        consumeFoodManager.Table.SetActive(true);
        if(Player.BoughtFood.Count > 0)
            CheckFoodCountIfOne();                 
    }
    private void CheckFoodCountIfOne(){
        consumeFoodManager.Meal.SetActive(true);
        consumeFoodManager.ItemCountUI.SetActive(true);

        if(Player.BoughtFood.Count != 1){
            consumeFoodManager.Left.SetActive(true);
            consumeFoodManager.Right.SetActive(true);
        }  
    }
}
