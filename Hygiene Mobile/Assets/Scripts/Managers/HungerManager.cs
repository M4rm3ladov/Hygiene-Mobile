using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HungerManager : MonoBehaviour
{
    public float _max = 100;
    public Image CurrentHunger;
    public Text HungerText;
    public float _hungerTickRate;
    public float _hungerIncrease;
    private TimeSpan _timeDifference;
    private void Start() 
    {
        if(PlayerPrefs.GetInt("first") == 0)
            SubtractHungerPerDateTime();
        UpdateHungerBar();
    }
    private void OnApplicationPause(bool pauseStatus) {
        if(pauseStatus == false){
            SubtractHungerPerDateTime();
            UpdateHungerBar();
        }
    }
    private void SubtractHungerPerDateTime(){
        _timeDifference = DateTime.Now - Player.LastIn;
        Player.Hunger -= (float)(_hungerIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        if(Player.Hunger < 0)
            Player.Hunger = 0;
    }
    // Update is called once per frame
    void Update()
    {   
        //Reduce needs values per time passing of gameHour
        if(TimingManager.GameHourTimer < 0)
        {        
            ChangeHunger();             
            UpdateHungerBar();     
        }     
    } 
    //update the hungerbar UI
    public void UpdateHungerBar()
    {
        float ratio = Player.Hunger / _max;
        CurrentHunger.rectTransform.localScale = new Vector3(ratio, 1, 1);
        HungerText.text = (ratio * 100).ToString("0") + "%";
    }
    //depleting the hunger need with an alterable value
    public void ChangeHunger()
    {
        Player.Hunger -= _hungerTickRate * Time.deltaTime;
        if(Player.Hunger < 0 )
        {
            Player.Hunger = 0;
        }  
    }
}
