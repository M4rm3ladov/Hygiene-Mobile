using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnergyManager : MonoBehaviour
{
    public float _max = 100;
    public Image CurrentEnergy;
    public Text EnergyText;
    public float _energyTickRate;
    public float _energyIncrease;
    private TimeSpan _timeDifference;
    private void Start() 
    {
        if(PlayerPrefs.GetInt("first") == 0)
            SubtractEnergyPerDateTime();
        UpdateEnergyBar();
    }
    private void OnApplicationPause(bool pauseStatus) {
        if(pauseStatus == false){
            SubtractEnergyPerDateTime();
            UpdateEnergyBar();
        }
    }
    private void SubtractEnergyPerDateTime(){
        _timeDifference = DateTime.Now - Player.LastIn;
        if(Player.SleepState == 1)
            Player.Energy -= (float)(_energyIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        if(Player.Energy < 0)
            Player.Energy = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        //Reduce needs values per time passing of gameHour
        if(TimingManager.GameHourTimer < 0)
        {        
            if(Player.SleepState == 1)
            {
                ChangeEnergy();
            } 
            UpdateEnergyBar();     
        }     
    } 
    //update the energybar UI
    public void UpdateEnergyBar()
    {
        float ratio = Player.Energy / _max;
        CurrentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
        EnergyText.text = (ratio * 100).ToString("0") + "%";
    }
    //depleting the energy need with an alterable value
    public void ChangeEnergy()
    {
        Player.Energy -= _energyTickRate * Time.deltaTime;
        if(Player.Energy < 0 )
        {
            Player.Energy = 0;
        }  
    }
}
