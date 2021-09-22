using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HygieneManager : MonoBehaviour
{
    public float _max = 100;
    public Image CurrentHygiene;
    public Text HygieneText;
    public float _hygieneTickRate;
    public float _hygieneIncrease;
    private TimeSpan _timeDifference;
    private void Start() 
    {
        if(PlayerPrefs.GetInt("first") == 0)
            SubtractHygienePerDateTime();
        UpdateHygieneBar();
    }
    private void OnApplicationPause(bool pauseStatus) {
        if(pauseStatus == false){
            SubtractHygienePerDateTime();
            UpdateHygieneBar();
        }
    }
    private void SubtractHygienePerDateTime(){
        _timeDifference = DateTime.Now - Player.LastIn;
        Player.Hygiene -= (float)(_hygieneIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        if(Player.Hygiene < 0)
            Player.Hygiene = 0;
    }    // Update is called once per frame
    void Update()
    {   
        //Reduce needs values per time passing of gameHour
        if(TimingManager.GameHourTimer < 0)
        {        
            ChangeHygiene(); 
            UpdateHygieneBar();     
        }     
    } 
    //update the energybar UI
    public void UpdateHygieneBar()
    {
        float ratio = Player.Hygiene / _max;
        CurrentHygiene.rectTransform.localScale = new Vector3(ratio, 1, 1);
        HygieneText.text = (ratio * 100).ToString("0") + "%";
    }
    //depleting the energy need with an alterable value
    public void ChangeHygiene()
    {
        Player.Hygiene -= _hygieneTickRate * Time.deltaTime;
        if(Player.Hygiene < 0 )
        {
            Player.Hygiene = 0;
        }  
    }
}
