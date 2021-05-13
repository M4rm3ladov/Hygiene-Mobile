using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodController : MonoBehaviour
{
    [SerializeField]
    FoodManager foodManager;
    [SerializeField]
    MonetaryManager monetaryManager;
    [SerializeField]
    private Button LeftButton;
    [SerializeField]
    private Button RightButton;
    [SerializeField]
    private Text ItemText;
    [SerializeField]
    private Text StatsText;
    [SerializeField]
    private Text PriceText;
    [SerializeField]
    private Button BuyButton;
    private int currentOption = 0;
    private void Start() {
        Button btnLeft = LeftButton.GetComponent<Button>();
        btnLeft.onClick.AddListener(PreviousOption);

        Button btnRight = RightButton.GetComponent<Button>();
        btnRight.onClick.AddListener(NextOption);

        Button btnBuy = BuyButton.GetComponent<Button>();
        btnBuy.onClick.AddListener(BuyFood);

        LoadFoodInfo();
    }

    private void PreviousOption(){
        currentOption++;
        if(currentOption > foodManager.FoodSpriteOptions.Count -1)
            currentOption = 0;
        LoadFoodInfo();
    }
    private void NextOption(){
        currentOption--;
        if(currentOption < 0)
            currentOption = foodManager.FoodSpriteOptions.Count - 1;
        LoadFoodInfo();
    }
    public void LoadFoodInfo(){
        foodManager.Food.sprite = foodManager.FoodSpriteOptions[currentOption];
        ItemText.text = foodManager.Food.sprite.name;
        StatsText.text = "+" + foodManager.FoodStats[currentOption].ToString() + "%";
        PriceText.text = foodManager.FoodPrices[currentOption].ToString();
    }
    public void BuyFood(){
        if(CheckFoodExistsInDictionary())
            Player.BoughtFood.Add(foodManager.Food.sprite.name, 1);
        Debug.Log(Player.BoughtFood[foodManager.Food.sprite.name]);
    }
    public bool CheckFoodExistsInDictionary(){
        if(Player.BoughtFood.ContainsKey(foodManager.Food.sprite.name)){
            Player.BoughtFood[foodManager.Food.sprite.name]++;
            return false;
        }
        return true;
    }
}
