using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PlayerData
{
    public float hygiene;
    public float hunger;
    public float energy;
    public int sleepState;
    public string lastIn;
    public float goldCoins;
    public int[] equippedSkins = new int[2];
    public int[][] boughtSkins = new int[2][]{
    new int[6],
    new int[6]};
    public Dictionary<string, int> boughtFood = new Dictionary<string, int>();
    //public int toiletStatus;
    public string lastAte;
    public PlayerData(Player player)
    {
        hygiene = Player.Hygiene;
        hunger = Player.Hunger;
        energy = Player.Energy;
        sleepState = Player.SleepState;
        lastIn = Player.LastIn;//DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        goldCoins = Player.GoldCoins;

        for (int item = 0; item < Player.EquippedSkins.Length; item++)
        {
            equippedSkins[item] = Player.EquippedSkins[item];
        }

        for (int i = 0; i < Player.BoughtSkins.Length; i++)
        {
            for (int j = 0; j < Player.BoughtSkins[i].Length; j++)
            {
                boughtSkins[i][j] = Player.BoughtSkins[i][j];      
            }      
        }
        boughtFood = Player.BoughtFood;
        //toiletStatus = Player.ToiletStatus;
        lastAte = Player.LastAte;
    }
}
