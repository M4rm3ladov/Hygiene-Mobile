﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeFoodController : MonoBehaviour
{
    [SerializeField]
    FoodManager foodManager;
    [SerializeField]
    MonetaryManager monetaryManager;
    [SerializeField]
    private Text ItemCount;
    private int foodSpriteOptionsIterator;
    private List<string> foodIndex = new List<string>();
    private int currentOption = 0;
    public int CurrentOption{
        get{ return currentOption;} 
        set{ currentOption = value;}
    }
    public List<string> FoodIndex{
        get{ return foodIndex;} 
        set{ foodIndex = value;}
    }
    private void Start() {
        //checks if bought food is empty
        if(Player.BoughtFood.Count < 1)
            return;
        //stores bought food dictionary to list for index iteration access
        foreach (KeyValuePair<string, int> _key in Player.BoughtFood)   
            foodIndex.Add(_key.Key);
        //set default food on table
        LoadFoodToTable();
    }
    public void PreviousOption(){
        currentOption++;
        if(currentOption > Player.BoughtFood.Count - 1)
            currentOption = 0;
        LoadFoodToTable();   
    }
    public void NextOption(){
        currentOption--;
        if(currentOption < 0)
            currentOption = Player.BoughtFood.Count - 1;
        LoadFoodToTable();
    }
    private void LoadFoodToTable(){
        foodSpriteOptionsIterator = 0;
        foreach (Sprite foodSprite in foodManager.FoodSpriteOptions)
        {
            if(foodSprite.name.ToString() == foodIndex[currentOption]){
                foodManager.Food.sprite = foodManager.FoodSpriteOptions[foodSpriteOptionsIterator];
                ItemCount.text = Player.BoughtFood[foodIndex[currentOption]].ToString();
            }
            foodSpriteOptionsIterator++;
        }
    }
    public void BuyFood(){
        if(CheckFoodExistsInDictionary())
            Player.BoughtFood.Add(foodManager.Food.sprite.name, 1);
        Debug.Log(Player.BoughtFood[foodManager.Food.sprite.name]);
        monetaryManager.ComputeBoughtItem(foodManager.FoodPrices[currentOption]);
    }
    private bool CheckFoodExistsInDictionary(){
        if(Player.BoughtFood.ContainsKey(foodManager.Food.sprite.name)){
            Player.BoughtFood[foodManager.Food.sprite.name]++;
            return false;
        }
        return true;
    }
}
