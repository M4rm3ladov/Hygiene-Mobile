using System.Collections;
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
    public static string LastIn;
    public static float GoldCoins = 100;
    public static int[] EquippedSkins = new int[2]{0,0};
    public static int[][] BoughtSkins = new int[2][]{
        new int[6]{1,0,0,0,0,0},
        new int[6]{1,0,0,0,0,0}
    };
    public static Dictionary<string, int> BoughtFood = new Dictionary<string, int>();
    //public static int ToiletStatus = 0;
    public static string LastAte;
    public static int[] HighScore = new int[3]{0,0,0};
    public static float Volume = .15f;
    public static bool SoundOn = true;
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
        LastIn = data.lastIn;
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
        //ToiletStatus = data.toiletStatus;
        LastAte = data.lastAte;
        for (int item = 0; item < data.highScore.Length; item++)
        {
            HighScore[item] = data.highScore[item];
        }
        Volume = data.volume;
        SoundOn = data.soundOn;
    }
    private void OnApplicationQuit() {
        LastIn = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Kitchen"){
            if(KitchenStatus.EatStatus != 0 || KitchenStatus.ToothbrushStatus != 0){
                Hygiene = Hygiene - 70f;
            }
        }else if(BathroomStatus.ToiletStatus == 2){
            Hygiene = Hygiene - 70f;
        }
        SavePlayer();
    }
    private void OnApplicationPause(bool pauseStatus) {
        if(pauseStatus){
            PlayerPrefs.SetInt("first", 0);
            //Debug.Log("fuck");
            Player.LastIn = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            SavePlayer();
        }
        else{
            //LoadPlayer();
            //Debug.Log("you");
        }
    }
    /*private void OnApplicationFocus(bool focusStatus) {
        if(focusStatus)
            LoadPlayer();
    }*/
    private void Awake() {
        //Debug.Log(BathroomStatus.ToiletStatus);
        LoadPlayer();
        //if(EatingStatus == 1)
        //    Hygiene = Hygiene - 70f;       
        //Input.backButtonLeavesApp = true;
    }
    private void OnDestroy() {
        Player.LastIn = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        SavePlayer();
    }
    private void Update() {
        //SavePlayer();
    }
}
