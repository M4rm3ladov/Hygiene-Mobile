using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveController : MonoBehaviour
{
    [SerializeField]
    private GameObject Meal;
    [SerializeField]
    private GameObject ItemCount;
    [SerializeField]
    private GameObject Table;
    [SerializeField]
    private GameObject Left;
    [SerializeField]
    private GameObject Right;
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
        Meal.SetActive(false);
        ItemCount.SetActive(false);
        Table.SetActive(false);
        Left.SetActive(false);
        Right.SetActive(false);
    }
    private void CheckFoodCount(){
        _clicked = 1;
        Table.SetActive(true);
        if(Player.BoughtFood.Count > 0)
            CheckFoodCountIfOne();                 
    }
    private void CheckFoodCountIfOne(){
        Meal.SetActive(true);
        ItemCount.SetActive(true);

        if(Player.BoughtFood.Count != 1){
            Left.SetActive(true);
            Right.SetActive(true);
        }  
    }
}
