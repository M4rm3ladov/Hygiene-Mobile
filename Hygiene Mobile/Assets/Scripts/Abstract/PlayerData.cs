using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float hygiene;
    public float hunger;
    public float energy;
    public int sleepState;
    public PlayerData(Player player)
    {
        hygiene = Player.Hygiene;
        hunger = Player.Hunger;
        energy = Player.Energy;
        sleepState = Player.SleepState;
    }
}
