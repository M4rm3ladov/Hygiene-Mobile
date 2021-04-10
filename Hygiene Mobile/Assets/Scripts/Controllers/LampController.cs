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
    //max of the energy bar
    private float _max = 100;
    [SerializeField]
    private Image CurrentEnergy;
    [SerializeField]
    public Text EnergyText;
    [SerializeField]
    private float _energyTickRate;
    [SerializeField]
    private float _energyIncrease;
    private TimeSpan _timeDifference;
    //loads sleep state of player
    private void Start() 
    {
        //calculates the time last in and out then added the product to the energy
        _timeDifference = DateTime.Now - Player.LastIn;
        if(Player.SleepState == 0)
        {
            TurnOffLight();
            Player.Energy += (float)(_energyIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        }else
        {
            TurnOnLight();
            Player.Energy -= (float)(_energyIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        }
        //to avoid delayed Energy Bar update 
        if(Player.Energy < 0){
            Player.Energy = 0;
        }else if(Player.Energy > _max){
            Player.Energy = _max;
        }
        UpdateEnergyBar();
    }
    void Update()
    {   
        //Reduce needs values per time passing of gameHour
        if(TimingManager.GameHourTimer < 0)
        { 
            if(Player.SleepState == 0)
            {
                Debug.Log("Moshi");
                RestTheChar();
            }
            else
            {
                ChangeEnergy();
            } 
            UpdateEnergyBar();     
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
    }
    //change values of bar and its indicator
    private void UpdateEnergyBar()
    {
        float ratio = Player.Energy / _max;
        CurrentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
        EnergyText.text = (ratio * 100).ToString("0") + "%";
    }
    //depleting the energy need with an alterable value
    private void ChangeEnergy()
    {
        Player.Energy -= _energyTickRate * Time.deltaTime;
        if(Player.Energy < 0 )
        {
            Player.Energy = 0;
        }  
    }
    //satisfying the energy need with an alterable value
    public void RestTheChar()
    {
        Player.Energy += _energyIncrease * Time.deltaTime;
        if(Player.Energy > _max)
        {
            Player.Energy = _max;
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
