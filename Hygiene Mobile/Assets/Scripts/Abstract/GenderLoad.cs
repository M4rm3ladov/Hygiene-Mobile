using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderLoad : MonoBehaviour
{
    [SerializeField]
    GameObject Boy;
    [SerializeField]
    GameObject Girl;
    private int gender;
    // Start is called before the first frame update
    void Awake() {
        gender = PlayerPrefs.GetInt("gender");

        if(gender == 0){
            Boy.active = true;
            Debug.Log("invoked");
        } 
        else if(gender == 1)
            Girl.active  = true;
    }
}
