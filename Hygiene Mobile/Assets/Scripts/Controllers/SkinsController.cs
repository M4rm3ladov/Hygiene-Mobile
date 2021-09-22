using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsController : MonoBehaviour
{
    #region declarations
    //[SerializeField]
    SkinsManager skinsManager;
    [SerializeField]
    MonetaryManager monetaryManager;
    [Header("Hair Prices")]
    public List<float> HairPrices = new List<float>();
    [Header("Clothes Prices")]
    public List<float> ClothesPrices = new List<float>(); 
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
    private GameObject CoinImage;
    [SerializeField]
    private GameObject BuyButton;
    [SerializeField]
    private GameObject EquipButton;
    //dictionary of hair and clothes index with names as value
    private Dictionary<int, string> hairNames = new Dictionary<int, string>();
    private Dictionary<int, string> clothesNames = new Dictionary<int, string>();
    private Dictionary<int, int> hairBought = new Dictionary<int, int>();
    private Dictionary<int, int> clothesBought = new Dictionary<int, int>();
    //trigger for hair and clothes buttons 1 or 0
    private int buttonOption = 0;
    //index for selected item
    private int currentOption;
    //default index of hair and clothe in relation to sprite
    private int defaultHair;
    private int defaultClothes;
    #endregion
    // Start is called before the first frame update
    #region start
    void Start()
    {
        skinsManager = GameObject.Find("Body").GetComponent<SkinsManager>();

        Button btnLeft = LeftButton.GetComponent<Button>();
        btnLeft.onClick.AddListener(PreviousOption);

        Button btnRight = RightButton.GetComponent<Button>();
        btnRight.onClick.AddListener(NextOption);

        Button btnHair = HairButton.GetComponent<Button>();
        btnHair.onClick.AddListener(HairClick);

        Button btnClothes = ClothesButton.GetComponent<Button>();
        btnClothes.onClick.AddListener(ClothesClick);

        Button btnBuy = BuyButton.GetComponent<Button>();
        btnBuy.onClick.AddListener(BuyItem);

        Button btnEquip = EquipButton.GetComponent<Button>();
        btnEquip.onClick.AddListener(EquipItem);

        int gender = PlayerPrefs.GetInt("gender");
        if(gender == 0){
            //item names to dictionary
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
        }else if(gender == 1){
            hairNames.Add(0,"Ponytail");
            hairNames.Add(1,"Ox horns");
            hairNames.Add(2,"Short");
            hairNames.Add(3,"Hat");
            hairNames.Add(4,"Amazon");
            hairNames.Add(5,"Braided");

            clothesNames.Add(0,"Sando");
            clothesNames.Add(1,"Qipao");
            clothesNames.Add(2,"Sporty");
            clothesNames.Add(3,"Casual");
            clothesNames.Add(4,"Super Woman");
            clothesNames.Add(5,"Gown");

        }
        //items bought to dictionary
        for (int i = 0; i < Player.BoughtSkins.Length; i++)
        {
            for (int j = 0; j < Player.BoughtSkins[i].Length; j++)
            {
                if(i == 0)
                    hairBought.Add(j, Player.BoughtSkins[i][j]);
                else
                    clothesBought.Add(j, Player.BoughtSkins[i][j]);
            }      
        }
        //set item name of currently equipped hair
        ItemText.text = hairNames[Player.EquippedSkins[0]];
        //set default items 
        defaultHair = Player.EquippedSkins[0];
        defaultClothes = Player.EquippedSkins[1];
        currentOption = defaultHair;
        //set button to button equip
        EquipButtonTransition();
        //set hair button to uninteractable since selected by default
        HairButton.interactable = false;
    }
    #endregion
    #region left-right-buttons
    private void PreviousOption(){
        if(buttonOption == 0){
            currentOption++;
            if(currentOption > skinsManager.HairSpriteOptions.Count -1)
                currentOption = 0;

            CheckHairBought();
            LoadHair();    
        }else{
            currentOption++;
            if(currentOption > skinsManager.TorsoSpriteOptions.Count - 1)
                currentOption = 0;

            CheckClothesBought();
            LoadClothes();
        }
    }
    private void NextOption(){
        if(buttonOption == 0){
            currentOption--;
            if(currentOption < 0)
                currentOption = skinsManager.HairSpriteOptions.Count - 1;
            
            CheckHairBought();
            LoadHair();
        }else{
            currentOption--;
            if(currentOption < 0)
                currentOption = skinsManager.TorsoSpriteOptions.Count - 1;
            
            CheckClothesBought();
            LoadClothes();
        }
    }
    #endregion
    #region hair-clothes-methods
    private void CheckHairBought(){
        if(hairBought[currentOption] == 0)
            BuyButtonTransition();
        else
            EquipButtonTransition();
    }
    private void CheckClothesBought(){
        if(clothesBought[currentOption] == 0)
            BuyButtonTransition();
        else
            EquipButtonTransition();
    } 
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
    }   
    private void LoadClothes(){
        skinsManager.Torso.sprite = skinsManager.TorsoSpriteOptions[currentOption];
        skinsManager.LeftArm.sprite = skinsManager.LeftArmSpriteOptions[currentOption];
        skinsManager.RightArm.sprite = skinsManager.RightArmSpriteOptions[currentOption];
        skinsManager.LeftLeg.sprite = skinsManager.LeftLegSpriteOptions[currentOption];
        skinsManager.RightLeg.sprite = skinsManager.RightLegSpriteOptions[currentOption];
        ItemText.text = clothesNames[currentOption];
    }  
    private void HairClick(){
        buttonOption = 0;
        currentOption = 0;
        CheckHairBought();
        LoadDefaultClothes();
        ItemText.text = hairNames[defaultHair];
        HairButton.interactable = false;
        ClothesButton.interactable = true;
    }
    private void ClothesClick(){        
        buttonOption = 1;
        currentOption = 0;
        CheckClothesBought();
        LoadDefaultHair();
        ItemText.text = clothesNames[defaultClothes];
        ClothesButton.interactable = false;
        HairButton.interactable = true;
    }
    private void UpdateItemsDictionary(){
        for (int i = 0; i < Player.BoughtSkins.Length; i++)
        {
            for (int j = 0; j < Player.BoughtSkins[i].Length; j++)
            {
                if(i == 0)
                    hairBought[j] = Player.BoughtSkins[i][j];
                else
                    clothesBought[j] = Player.BoughtSkins[i][j];
            }      
        }
    }
    #endregion
    private void BuyButtonTransition(){
        if(buttonOption == 0)
            PriceText.text = HairPrices[currentOption].ToString();
        else
            PriceText.text = ClothesPrices[currentOption].ToString();
        CoinImage.SetActive(true);
        BuyButton.SetActive(true);
        EquipButton.SetActive(false);
    }
    private void EquipButtonTransition(){
        PriceText.text = "Equip";
        CoinImage.SetActive(false);
        BuyButton.SetActive(false);
        EquipButton.SetActive(true);
    }
    public void BuyItem(){
        //calculate bought item
        if(Player.GoldCoins < float.Parse(PriceText.text) )
            return;
        monetaryManager.ComputeBoughtItem(float.Parse(PriceText.text));
        
        EquipItem();
        EquipButtonTransition();
        if(buttonOption == 0)
            Player.BoughtSkins[0][currentOption] = 1;
        else
            Player.BoughtSkins[1][currentOption] = 1;
        UpdateItemsDictionary();
    }
    public void EquipItem(){
        if(buttonOption == 0){
            Player.EquippedSkins[0] = currentOption;
            defaultHair = currentOption;
        }else{
            Player.EquippedSkins[1] = currentOption;
            defaultClothes = currentOption;
        }
    }
}
