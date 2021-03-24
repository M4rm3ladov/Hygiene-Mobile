using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    //Initialize global time length
    public static float GameHourTimer;
    //Initialize default time length
    [SerializeField]
    private float _hourLegnth;

    private void Update() 
    {
        if (GameHourTimer <= 0)
        {
            GameHourTimer = _hourLegnth;
        }else{
            GameHourTimer -= Time.deltaTime;
        }
    }
}
