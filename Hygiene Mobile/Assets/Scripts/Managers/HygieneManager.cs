using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HygieneManager : MonoBehaviour
{
    Player player;
    public float _max = 100;
    public Image CurrentHygiene;
    public Text HygieneText;
    public float _hygieneTickRate;
    public float _hygieneIncrease;
    private TimeSpan _timeDifference;
    private void Start() 
    {
        if(PlayerPrefs.GetInt("gender") == 0)
            player = GameObject.Find("Player").GetComponent<Player>();
        if(PlayerPrefs.GetInt("gender") == 1)
            player = GameObject.Find("Girl").GetComponent<Player>();
        
        if(PlayerPrefs.GetInt("first") == 0)
            SubtractHygienePerDateTime();
        UpdateHygieneBar();
        Debug.Log("gege" + Player.Hygiene);
    }
    private void OnApplicationFocus(bool focusStatus) {
        if(focusStatus){
            player.LoadPlayer();
            if(PlayerPrefs.GetInt("first") == 0)
                SubtractHygienePerDateTime();
            UpdateHygieneBar();
            Debug.Log("negus" + Player.Hygiene);
        }
    }
    private void SubtractHygienePerDateTime(){
        _timeDifference = DateTime.Now - DateTime.Parse(Player.LastIn);
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
        //if(counter == 0 ){
          //  counter ++; 
            Debug.Log("feg" + Player.Hygiene); 
        //} 
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
