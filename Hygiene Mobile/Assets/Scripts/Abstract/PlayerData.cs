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
    public int[] equippedSkins = new int[2];
    /*public int[][] boughtItems = new int[6][]{
    new int[6],
    new int[6],
    new int[6],
    new int[6],
    new int[6],
    new int[6]};*/
    public PlayerData(Player player)
    {
        hygiene = Player.Hygiene;
        hunger = Player.Hunger;
        energy = Player.Energy;
        sleepState = Player.SleepState;
        lastIn = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

        for (int item = 0; item < Player.EquippedSkins.Length; item++)
        {
            equippedSkins[item] = Player.EquippedSkins[item];
        }

        /*for (int i = 0; i < Player.BoughtItems.Length; i++)
        {
            for (int j = 0; j < Player.BoughtItems[i].Length; j++)
            {
                boughtItems[i][j] = Player.BoughtItems[i][j];      
            }      
        }*/
    }
}
