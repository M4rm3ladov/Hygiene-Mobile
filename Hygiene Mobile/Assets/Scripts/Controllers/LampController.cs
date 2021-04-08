using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //light switch on-1 and off-0
    private float _max = 100;
    [SerializeField]
    private Image CurrentEnergy;
    [SerializeField]
    public Text EnergyText;
    [SerializeField]
    private float _energyTickRate;
    [SerializeField]
    private float _energyIncrease;
    //loads sleep state of player
    private void Start() 
    {
        if(Player.SleepState == 0)
        {
            TurnOffLight();
        }else
        {
            TurnOnLight();
        }
    }
    void Update()
    {   
        //Reduce needs values per time passing of gameHour
        if(TimingManager.GameHourTimer < 0)
        { 
            if(Player.SleepState == 0)
            {
                Debug.Log("MOshi");
                RestTheChar();
            }
            else
            {
                ChangeEnergy();
            } 
            UpdateEnergyBar();     
        }     
    }
    private void UpdateEnergyBar()
    {
        float ratio = Player.Energy / _max;
        CurrentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
        EnergyText.text = (ratio * 100).ToString("0") + "%";
    }
    private void ChangeEnergy()
    {
        Player.Energy -= _energyTickRate * Time.deltaTime;
        if(Player.Energy < 0 )
        {
            Player.Energy = 0;
        }
      
    }
    public void RestTheChar()
    {
        Player.Energy += _energyIncrease * Time.deltaTime;
        if(Player.Energy > _max)
        {
            Player.Energy = _max;
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
