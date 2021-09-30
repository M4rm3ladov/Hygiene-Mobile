using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QTipCottonController : MonoBehaviour
{
    private List<GameObject> virus = new List<GameObject>();   
    private string vName;
    private int index;
    private float timeStep = .5f;
    private float addend = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
            virus.Add(GameObject.Find("faceSprite").transform.GetChild(i).gameObject);
    }
    private void OnTriggerStay2D(Collider2D other) {
        for (int i = 0; i < virus.Count; i++)
        {
            index = i;
            if(virus[i].name == other.name){
                vName = virus[i].name;
                break;
            }
        }

        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(vName == other.name)
                timeStep -= Time.deltaTime;  
        } 

        if(timeStep <= 0){
            virus[index].SetActive(false); 
            virus.RemoveAt(index); 
            timeStep = .5f;
            BathroomManager.BathStep += addend;
        }
    }

}
