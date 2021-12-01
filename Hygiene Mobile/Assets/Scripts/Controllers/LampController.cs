using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LampController : MonoBehaviour
{
    Player player;
    SkinsManager skinsManager;
    PlayerController playerController;
    [SerializeField]
    private SpriteRenderer hair;
    //Panel light effect initialization
    [SerializeField]
    private GameObject RoomLight;
    //Player Body for enabling and disabling initialization
   // [SerializeField]
    private GameObject Body;
    //Head for sleeping initialization
    [SerializeField]
    private GameObject SleepHead;
    private TimeSpan _timeDifference;
    [SerializeField]
    NeedsController needsController;
    //[SerializeField]
    //EnergyManager energyManager;
    
    //loads sleep state of player
    private void Start() 
    {
        if(PlayerPrefs.GetInt("gender") == 0){
            player = GameObject.Find("Player").GetComponent<Player>();
            Body = GameObject.Find("Player").transform.GetChild(0).gameObject;
            skinsManager = GameObject.Find("Player").GetComponentInChildren<SkinsManager>();
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }
        else if(PlayerPrefs.GetInt("gender") == 1){
            player = GameObject.Find("Girl").GetComponent<Player>();
            Body = GameObject.Find("Girl").transform.GetChild(0).gameObject;
            skinsManager = GameObject.Find("Girl").GetComponentInChildren<SkinsManager>();
            playerController = GameObject.Find("Girl").GetComponent<PlayerController>();
        }
        hair.sprite = skinsManager.HairSpriteOptions[Player.EquippedSkins[0]];
        //calculates the time last in and out then added the product to the energy
        _timeDifference = DateTime.Now - DateTime.Parse(Player.LastIn);
        if(Player.SleepState == 0)
        {
            TurnOffLight();
            Player.Energy += (float)(needsController._energyIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        }else
        {
            TurnOnLight();
        }
        //to avoid delayed Energy Bar update 
        if(Player.Energy > needsController._max)
            Player.Energy = needsController._max;
    
        needsController.UpdateEnergyBar();
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
        Player.Energy += needsController._energyIncrease * Time.deltaTime;
        if(Player.Energy > needsController._max)
        {
            Player.Energy = needsController._max;
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
            player.SavePlayer();
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
            player.SavePlayer();
    }
    private bool CheckHungryOrDirty(){
        if(BathroomStatus.ToiletStatus >= 1 && ((int)Player.Hunger <= playerController.HungerTrigger || (int)Player.Hygiene <= playerController.HygieneTrigger))
            return true;
        else
            return false;
    }
}
