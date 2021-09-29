using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderLoad : MonoBehaviour
{
    [SerializeField]
    GameObject boy;
    [SerializeField]
    GameObject girl;
    public GameObject Boy{
        get{return boy;}
        set{boy = value;}
    }
    public GameObject Girl{
        get{return girl;}
        set{girl = value;}
    }
    private int gender;
    // Start is called before the first frame update
    void Awake() {
        gender = PlayerPrefs.GetInt("gender");

        if(gender == 0){
            boy.SetActive(true);
            Debug.Log("invoked");
        } 
        else if(gender == 1)
            girl.SetActive(true);
    }
}
