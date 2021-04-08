using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float Hygiene = 100;
    public static float Hunger = 100;
    public static float Energy = 100;
    public static int SleepState = 1;
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer(); 
        Hygiene = data.hygiene;
        Hunger = data.hunger;
        Energy = data.energy;
        SleepState = data.sleepState;
    }
    private void OnApplicationQuit() {
        SavePlayer();
    }
    private void OnApplicationPause(bool pauseStatus) {
        if(pauseStatus)
        {
            SavePlayer();
        }else
        {
            LoadPlayer();
        }
    }
    private void Awake() {
        LoadPlayer();
        Input.backButtonLeavesApp = true;

    }
    
}
