using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gender : MonoBehaviour
{
    public void ChooseBoy(){
        PlayerPrefs.SetInt("gender", 0);
    }
    public void ChooseGirl(){
        PlayerPrefs.SetInt("gender", 1);
    }
}
