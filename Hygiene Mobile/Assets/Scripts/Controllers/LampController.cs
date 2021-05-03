using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LampController : MonoBehaviour
{
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
    [SerializeField]
    PlayerController playerController;
    
    
    //loads sleep state of player
    private void Start() 
    {
        //calculates the time last in and out then added the product to the energy
        _timeDifference = DateTime.Now - Player.LastIn;
        if(Player.SleepState == 0)
        {
            TurnOffLight();
            Player.Energy += (float)(energyManager._energyIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        }else
        {
            TurnOnLight();
            Player.Energy -= (float)(energyManager._energyIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        }
        //to avoid delayed Energy Bar update 
        if(Player.Energy < 0){
            Player.Energy = 0;
        }else if(Player.Energy > energyManager._max){
            Player.Energy = energyManager._max;
        }
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
            TurnOffLight();  
        }
        
        else if(Player.SleepState == 0)
        {   
           TurnOnLight();
        }
        //checks after lamp press if player rested
        /*if((int)Player.Energy >= playerController.tiredTrigger)
        {
            playerController.animTransition.SetTrigger("Idle");
            //Debug.Log("rested");
            //playerController.NormalStateTransition();
        }*/ 
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
}
