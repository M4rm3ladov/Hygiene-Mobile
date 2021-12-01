using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NeedsController : MonoBehaviour
{
    Player player;
    public float _max = 100;
    //Hygiene
    public Image CurrentHygiene;
    public Text HygieneText;
    public float _hygieneTickRate;
    public float _hygieneIncrease;
    //Hunger
    public Image CurrentHunger;
    public Text HungerText;
    public float _hungerTickRate;
    public float _hungerIncrease;
    //Energy
    public Image CurrentEnergy;
    public Text EnergyText;
    public float _energyTickRate;
    public float _energyIncrease;
    private TimeSpan _timeDifference;
    void Start()
    {
        if(PlayerPrefs.GetInt("gender") == 0)
            player = GameObject.Find("Player").GetComponent<Player>();
        if(PlayerPrefs.GetInt("gender") == 1)
            player = GameObject.Find("Girl").GetComponent<Player>();

        if(PlayerPrefs.GetInt("first") == 0){
            SubtractHygienePerDateTime();
            SubtractHungerPerDateTime();
            SubtractEnergyPerDateTime();
        }
        UpdateHygieneBar();
        UpdateHungerBar();
        UpdateEnergyBar();
    }
    private void OnApplicationFocus(bool focusStatus) {
        if(focusStatus){
            player.LoadPlayer();
            if(PlayerPrefs.GetInt("first") == 0){
                SubtractHygienePerDateTime();
                SubtractHungerPerDateTime();
                SubtractEnergyPerDateTime();
            }
            UpdateHygieneBar();
            UpdateHungerBar();
            UpdateEnergyBar();
            //Debug.Log("negus" + Player.Hygiene);
        }//else
            
    }
    private void OnDestroy() {
        //Player.LastIn = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
    }
    // Update is called once per frame
    void Update()
    {   
        //Reduce needs values per time passing of gameHour
        if(TimingManager.GameHourTimer < 0)
        {
            ChangeHygiene();
            ChangeHunger();
            if(Player.SleepState == 1)
                ChangeEnergy();
        }  
        //Update UI
        UpdateHygieneBar();
        UpdateHungerBar();
        UpdateEnergyBar();
    }
    private void SubtractHygienePerDateTime(){
        _timeDifference = DateTime.Now - DateTime.Parse(Player.LastIn);
        Player.Hygiene -= (float)(_hygieneIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        if(Player.Hygiene < 0)
            Player.Hygiene = 0;
    }
    private void SubtractHungerPerDateTime(){
        _timeDifference = DateTime.Now - DateTime.Parse(Player.LastIn);
        Player.Hunger -= (float)(_hungerIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        if(Player.Hunger < 0)
            Player.Hunger = 0;
    }
    private void SubtractEnergyPerDateTime(){
        _timeDifference = DateTime.Now - DateTime.Parse(Player.LastIn);
        if(Player.SleepState == 1)
            Player.Energy -= (float)(_energyIncrease * _timeDifference.TotalSeconds * Time.deltaTime);
        if(Player.Energy < 0)
            Player.Energy = 0;
    }
    #region Reduce Needs
    private void ChangeHygiene()
    {
         Player.Hygiene -= _hygieneTickRate * Time.deltaTime;
        if(Player.Hygiene < 0 )
        {
            Player.Hygiene = 0;
        }
    }
    private void ChangeHunger()
    {
        Player.Hunger -= _hungerTickRate * Time.deltaTime;
        if(Player.Hunger < 0 )
        {
            Player.Hunger = 0;
        }
    }
    private void ChangeEnergy()
    {
        Player.Energy -= _energyTickRate * Time.deltaTime;
        if(Player.Energy < 0 )
        {
            Player.Energy = 0;
        }
    }
    #endregion
    #region Reduce Needs Bar
    public void UpdateHygieneBar()
    {
        float ratio = Player.Hygiene / _max;
        CurrentHygiene.rectTransform.localScale = new Vector3(ratio, 1, 1);
        HygieneText.text = (ratio * 100).ToString("0") + "%";
    }
    public void UpdateHungerBar()
    {
        float ratio = Player.Hunger / _max;
        CurrentHunger.rectTransform.localScale = new Vector3(ratio, 1, 1);
        HungerText.text = (ratio * 100).ToString("0") + "%";
    }
    public void UpdateEnergyBar()
    {
        float ratio = Player.Energy / _max;
        CurrentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
        EnergyText.text = (ratio * 100).ToString("0") + "%";
    }
    #endregion
    #region Satisfying Needs
    /*private void CleanTheChar()
    {
        Debug.Log("Clean clicked");
        Player.Hygiene += 10;
        if(Player.Hygiene > _max)
        {
            Player.Hygiene = _max;
        }
        UpdateCleanBar();
    }
    private void FeedTheChar()
    {
         Debug.Log("Feed clicked");
        Player.Hunger += 10;
        if(Player.Hunger > _max)
        {
            Player.Hunger = _max;
        }
        UpdateHungerBar();
    }
    /*public void RestTheChar()
    {
         Debug.Log("Energy clicked");
        Player.Energy += _energyIncrease;
        if(Player.Energy > _max)
        {
            Player.Energy = _max;
        }
        UpdateEnergyBar();
    }*/
    #endregion
}
