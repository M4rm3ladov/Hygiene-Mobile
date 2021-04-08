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
    public PlayerData(Player player)
    {
        hygiene = Player.Hygiene;
        hunger = Player.Hunger;
        energy = Player.Energy;
        sleepState = Player.SleepState;
        lastIn = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
    }
}
