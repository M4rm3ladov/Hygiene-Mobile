using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsController : MonoBehaviour
{
    [SerializeField]
    SkinsManager skinsManager;
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
    //0 for hair 1 for clothes
    private int buttonOption = 0;
    private int currentOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(skinsManager.HairSpriteOptions.Count);
        Button btnLeft = LeftButton.GetComponent<Button>();
        btnLeft.onClick.AddListener(PreviousOption);

        Button btnRight = RightButton.GetComponent<Button>();
        btnRight.onClick.AddListener(NextOption);

        Button btnHair = HairButton.GetComponent<Button>();
        btnHair.onClick.AddListener(HairClick);

        Button btnClothes = ClothesButton.GetComponent<Button>();
        btnClothes.onClick.AddListener(ClothesClick);
    }
    private void HairClick(){
        buttonOption = 0;
        currentOption = 0;
    }
    private void ClothesClick(){
        buttonOption = 1;
        currentOption = 0;
    }
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
    private void LoadHair(){
        skinsManager.Hair.sprite = skinsManager.HairSpriteOptions[currentOption];
        ItemText.text = skinsManager.HairNames[currentOption];
        PriceText.text = skinsManager.HairPrices[currentOption].ToString(); 
    }   
    private void LoadClothes(){
        skinsManager.Torso.sprite = skinsManager.TorsoSpriteOptions[currentOption];
        skinsManager.LeftArm.sprite = skinsManager.LeftArmSpriteOptions[currentOption];
        skinsManager.RightArm.sprite = skinsManager.RightArmSpriteOptions[currentOption];
        skinsManager.LeftLeg.sprite = skinsManager.LeftLegSpriteOptions[currentOption];
        skinsManager.RightLeg.sprite = skinsManager.RightLegSpriteOptions[currentOption];
        ItemText.text = skinsManager.ClothesNames[currentOption];
        PriceText.text = skinsManager.ClothesPrices[currentOption].ToString(); 
    }   
}
