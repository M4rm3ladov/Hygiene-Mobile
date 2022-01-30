using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodController : MonoBehaviour
{
    Player player;
    [SerializeField]
    FoodManager foodManager;
    [SerializeField]
    MonetaryManager monetaryManager;
    [SerializeField]
    private Text ItemText;
    [SerializeField]
    private Text StatsText;
    [SerializeField]
    private Text PriceText;
    [SerializeField]
    private GameObject pnlOut;
    private int currentOption = 0;
    private void Start() {
        player = GetComponent<Player>();
        LoadFoodInfo();
    }
    public void ClosePanel(){
        pnlOut.SetActive(false);
    }
    public void PreviousOption(){
        currentOption++;
        if(currentOption > foodManager.FoodSpriteOptions.Count -1)
            currentOption = 0;
        LoadFoodInfo();
    }
    public void NextOption(){
        currentOption--;
        if(currentOption < 0)
            currentOption = foodManager.FoodSpriteOptions.Count - 1;
        LoadFoodInfo();
    }
    private void LoadFoodInfo(){
        foodManager.Food.sprite = foodManager.FoodSpriteOptions[currentOption];
        ItemText.text = foodManager.Food.sprite.name;
        StatsText.text = "+" + foodManager.FoodStats[currentOption].ToString() + "%";
        PriceText.text = foodManager.FoodPrices[currentOption].ToString();
    }
    public void BuyFood(){
        if(Player.GoldCoins < float.Parse(PriceText.text) ){
            pnlOut.SetActive(true);
            return;
        }
    
        if(CheckFoodExistsInDictionary())
            Player.BoughtFood.Add(foodManager.Food.sprite.name, 1);
        monetaryManager.ComputeBoughtItem(foodManager.FoodPrices[currentOption]);

        FindObjectOfType<AudioManager>().Play("Buy"); 
        player.SavePlayer();
    }
    private bool CheckFoodExistsInDictionary(){
        if(Player.BoughtFood.ContainsKey(foodManager.Food.sprite.name)){
            Player.BoughtFood[foodManager.Food.sprite.name]++;
            return false;
        }
        return true;
    }
}
