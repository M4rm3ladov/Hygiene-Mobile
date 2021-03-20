using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    //Initialize global time length
    public static float gameHourTimer;
    //Initialize default time length
    [SerializeField]
    private float _hourLegnth;

    private void Update() 
    {
        if (gameHourTimer <= 0)
        {
            gameHourTimer = _hourLegnth;
        }else{
            gameHourTimer -= Time.deltaTime;
        }
    }
}
