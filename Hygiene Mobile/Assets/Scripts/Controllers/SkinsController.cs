﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsController : MonoBehaviour
{
    #region declarations
    [SerializeField]
    SkinsManager skinsManager;
    [Header("Hair Prices")]
    public List<float> HairPrices = new List<float>();
    [Header("Clothes Prices")]
    public List<float> ClothesPrices = new List<float>();   
    [Header("Bought Hairs")]
    public List<int> HairBought = new List<int>();
    [Header("Bought Clothes")]
    public List<int> ClothesBought = new List<int>();
    [SerializeField]
    private Button LeftButton;
    [SerializeField]
    private Button RightButton;
    [SerializeField]
    private Button HairButton;
    [SerializeField]
    private Button ClothesButton;
    [SerializeField]
    private Text ItemText;
    [SerializeField]
    private Text PriceText;
    [SerializeField]
    private Button EquipButton;
    //dictionary of hair and clothes index with names as value
    private Dictionary<int, string> hairNames = new Dictionary<int, string>();
    private Dictionary<int, string> clothesNames = new Dictionary<int, string>();
    //trigger for hair and clothes buttons 1 or 0
    private int buttonOption = 0;
    //index for selected item
    private int currentOption = 0;
    //trigger to check if item is equipped to change default hair or clothe
    private int equipClicked = 0;
    //default index of hair and clothe in relation to sprite
    private int defaultHair;
    private int defaultClothes;
    #endregion
    // Start is called before the first frame update
    #region start
    void Start()
    {
        hairNames.Add(0,"Bald");
        hairNames.Add(1,"Emo");
        hairNames.Add(2,"Head Band");
        hairNames.Add(3,"Hat");
        hairNames.Add(4,"Rock");
        hairNames.Add(5,"Oppa");

        clothesNames.Add(0,"Sando");
        clothesNames.Add(1,"Casual");
        clothesNames.Add(2,"Sporty");
        clothesNames.Add(3,"Jumper");
        clothesNames.Add(4,"Super Hero");
        clothesNames.Add(5,"Tuxedo");

        ItemText.text = hairNames[Player.EquippedSkins[0]];

        defaultHair = Player.EquippedSkins[0];
        defaultClothes = Player.EquippedSkins[1];

        Button btnLeft = LeftButton.GetComponent<Button>();
        btnLeft.onClick.AddListener(PreviousOption);

        Button btnRight = RightButton.GetComponent<Button>();
        btnRight.onClick.AddListener(NextOption);

        Button btnHair = HairButton.GetComponent<Button>();
        btnHair.onClick.AddListener(HairClick);

        Button btnClothes = ClothesButton.GetComponent<Button>();
        btnClothes.onClick.AddListener(ClothesClick);

        Button btnEquip = EquipButton.GetComponent<Button>();
        btnEquip.onClick.AddListener(EquipItem);
    }
    #endregion
    #region left-right-buttons
    private void PreviousOption(){
        if(buttonOption == 0){
            currentOption++;
            if(currentOption > skinsManager.HairSpriteOptions.Count -1)
            {
                currentOption = 0;
            }
            LoadHair();    
        }else{
            currentOption++;
            if(currentOption > skinsManager.TorsoSpriteOptions.Count - 1)
            {
                currentOption = 0;
            }
            LoadClothes();
        }
    }
    private void NextOption(){
        if(buttonOption == 0){
            currentOption--;
            if(currentOption < 0)
            {
                currentOption = skinsManager.HairSpriteOptions.Count - 1;
            }
            LoadHair();
        }else{
            currentOption--;
            if(currentOption < 0)
            {
                currentOption = skinsManager.TorsoSpriteOptions.Count - 1;
            }
            LoadClothes();
        }
    }
    #endregion
    #region hair-clothes-methods
    private void LoadDefaultHair(){
        skinsManager.Hair.sprite = skinsManager.HairSpriteOptions[defaultHair];
    }
    private void LoadDefaultClothes(){
        skinsManager.Torso.sprite = skinsManager.TorsoSpriteOptions[defaultClothes];
        skinsManager.LeftArm.sprite = skinsManager.LeftArmSpriteOptions[defaultClothes];
        skinsManager.RightArm.sprite = skinsManager.RightArmSpriteOptions[defaultClothes];
        skinsManager.LeftLeg.sprite = skinsManager.LeftLegSpriteOptions[defaultClothes];
        skinsManager.RightLeg.sprite = skinsManager.RightLegSpriteOptions[defaultClothes];
    }
    private void LoadHair(){
        skinsManager.Hair.sprite = skinsManager.HairSpriteOptions[currentOption];
        ItemText.text = hairNames[currentOption];
        PriceText.text = HairPrices[currentOption].ToString(); 
    }   
    private void LoadClothes(){
        skinsManager.Torso.sprite = skinsManager.TorsoSpriteOptions[currentOption];
        skinsManager.LeftArm.sprite = skinsManager.LeftArmSpriteOptions[currentOption];
        skinsManager.RightArm.sprite = skinsManager.RightArmSpriteOptions[currentOption];
        skinsManager.LeftLeg.sprite = skinsManager.LeftLegSpriteOptions[currentOption];
        skinsManager.RightLeg.sprite = skinsManager.RightLegSpriteOptions[currentOption];
        ItemText.text = clothesNames[currentOption];
        PriceText.text = ClothesPrices[currentOption].ToString(); 
    }   
    #endregion
    private void HairClick(){
        buttonOption = 0;
        currentOption = 0;
        LoadDefaultClothes();
        ItemText.text = hairNames[defaultHair];
    }
    private void ClothesClick(){        
        buttonOption = 1;
        currentOption = 0;
        LoadDefaultHair();
        ItemText.text = clothesNames[defaultClothes];
    }
    public void EquipItem(){
        if(buttonOption == 0){
            Player.EquippedSkins[0] = currentOption;
            equipClicked = 1;
            defaultHair = currentOption;
        }else{
            Player.EquippedSkins[1] = currentOption;
            equipClicked = 1;
            defaultClothes = currentOption;
        }
    }
}
