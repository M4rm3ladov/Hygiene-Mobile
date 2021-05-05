using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static float Hygiene = 100;
    public static float Hunger = 100;
    public static float Energy = 100;
    public static int SleepState = 1;
    public static DateTime LastIn;
    public static int[] EquippedSkins = new int[2]{0,0};
    /*public static int[][] BoughtItems = new int[6][]{
        new int[6]{1,0,0,0,0,0},
        new int[6]{1,0,0,0,0,0},
        new int[6]{1,0,0,0,0,0},
        new int[6]{1,0,0,0,0,0},
        new int[6]{1,0,0,0,0,0},
        new int[6]{1,0,0,0,0,0}
    };*/
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
        LastIn = DateTime.Parse(data.lastIn);
        for (int item = 0; item < data.equippedSkins.Length; item++)
        {
            EquippedSkins[item] = data.equippedSkins[item];
        }
        /*for (int i = 0; i < data.boughtItems.Length; i++)
        {
            for (int j = 0; j < data.boughtItems[i].Length; j++)
            {
                BoughtItems[i][j] = data.boughtItems[i][j];
            }      
        }*/
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
    private void OnDestroy() {
        SavePlayer();
    }
    
}
