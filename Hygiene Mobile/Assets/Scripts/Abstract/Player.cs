﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static float Hygiene = 100;
    public static float Hunger = 100;
    public static float Energy = 100;
    public static int SleepState = 1;
    public static DateTime LastIn;
    public static float GoldCoins = 1000;
    public static int[] EquippedSkins = new int[2]{0,0};
    public static int[][] BoughtSkins = new int[2][]{
        new int[6]{1,0,0,0,0,0},
        new int[6]{1,0,0,0,0,0}
    };
    public static Dictionary<string, int> BoughtFood = new Dictionary<string, int>();
    public static int EatingStatus = 0;
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
        GoldCoins = data.goldCoins;
        for (int item = 0; item < data.equippedSkins.Length; item++)
        {
            EquippedSkins[item] = data.equippedSkins[item];
        }
        for (int i = 0; i < data.boughtSkins.Length; i++)
        {
            for (int j = 0; j < data.boughtSkins[i].Length; j++)
            {
                BoughtSkins[i][j] = data.boughtSkins[i][j];
            }      
        }
        BoughtFood = data.boughtFood;
        EatingStatus = data.eatingStatus;
    }
    /*private void OnApplicationQuit() {
        //SavePlayer();

        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Kitchen"){
            if(KitchenStatus.EatStatus != 0 || KitchenStatus.ToothbrushStatus != 0){
                Hygiene = Hygiene - 70f;
            }
        }
    }*/
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
        if(EatingStatus == 1)
            Hygiene = Hygiene - 70f;       
        Input.backButtonLeavesApp = true;
    }
    /*private void OnDestroy() {
        SavePlayer();
    }*/
    private void Update() {
         SavePlayer();
    }
}
