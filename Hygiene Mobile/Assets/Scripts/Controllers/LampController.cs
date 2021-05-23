using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LampController : MonoBehaviour
{
    [SerializeField]
    SkinsManager skinsManager;
    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    private SpriteRenderer hair;
    //Panel light effect initialization
    [SerializeField]
    private GameObject RoomLight;
    //Player Body for enabling and disabling initialization
    [SerializeField]
    private GameObject Body;
    //Head for sleeping initialization
    [SerializeField]
    private GameObject SleepHead;
    private TimeSpan _timeDifference;
    [SerializeField]
    EnergyManager energyManager;
    
    //loads sleep state of player
    private void Start() 
    {
        hair.sprite = skinsManager.HairSpriteOptions[Player.EquippedSkins[0]];
        //calculates the time last in and out then added the product to the energy
        _timeDifference = DateTime.Now - Player.LastIn;
        if(Player.SleepState == 0)
        {
            TurnOffLight();
            Player.Energy += (float)(energyManager._energyIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        }else
        {
            TurnOnLight();
        }
        //to avoid delayed Energy Bar update 
        if(Player.Energy > energyManager._max)
            Player.Energy = energyManager._max;
    
        energyManager.UpdateEnergyBar();
    }
    private void Update() {
        if(TimingManager.GameHourTimer < 0)
        {
            if(Player.SleepState == 0)
            {
                RestTheChar();
            }
        }   
    } 
    private void OnMouseDown() {
        if(Player.SleepState == 1)
        {
            if(!CheckHungryOrDirty())
                TurnOffLight();  
        }
        
        else if(Player.SleepState == 0)
        {   
           TurnOnLight();
        }
    }
    //satisfying the energy need with an alterable value
    public void RestTheChar()
    {
        Player.Energy += energyManager._energyIncrease * Time.deltaTime;
        if(Player.Energy > energyManager._max)
        {
            Player.Energy = energyManager._max;
        }
    }
    private void TurnOffLight()
    {
        //gameobjects Room light activate, Body deactivate and light switch state to ON
            RoomLight.SetActive(true);
            Body.SetActive(false);
            Player.SleepState = 0; 
            //Access SleepHead children's sprite renderers and enabling it
            SpriteRenderer[] sprites = SleepHead.GetComponentsInChildren<SpriteRenderer>();
            for(int i = 0; i < sprites.Length; i++){
                sprites[i].enabled = true;
            }  
    }
    private void TurnOnLight()
    {
         //opposite of comments above
            RoomLight.SetActive(false);
            Body.SetActive(true);
            Player.SleepState = 1;

            SpriteRenderer[] sprites = SleepHead.GetComponentsInChildren<SpriteRenderer>();
            for(int i = 0; i < sprites.Length; i++){
                sprites[i].enabled = false;
            }
    }
    private bool CheckHungryOrDirty(){
        if((int)Player.Hunger <= playerController.HungerTrigger)
            return true;
        else
            return false;
    }
}
