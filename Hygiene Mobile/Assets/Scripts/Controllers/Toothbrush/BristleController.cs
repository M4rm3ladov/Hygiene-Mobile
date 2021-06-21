using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BristleController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> mouth = new List<GameObject>();
    
    [SerializeField]
    ToothbrushManager toothbrushManager;
    [SerializeField]
    FrontTeethManager frontTeethManager;
    private float timeStep = 1.5f;
    private bool match = false;
    private string vName;
    private int index;
    private void Update() {
        if(frontTeethManager.Virus.Count == 0){
            mouth[0].SetActive(false);
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[0];
            mouth[1].SetActive(true);
            SinkManager.ToothbrushStep = 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        timeStep = 1.5f;
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.name == "top" || other.name == "bottom"){
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[2];
            SinkManager.ToothbrushStep = 2;
        }
        if(other.name == "topL" || other.name == "bottomL"){
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[4];
            SinkManager.ToothbrushStep = 2;
        }
        if(other.name == "topR" || other.name == "bottomR"){
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[3];
            SinkManager.ToothbrushStep = 2;
        }

        for (int i = 0; i < frontTeethManager.Virus.Count; i++)
        {
            index = i;
            if(frontTeethManager.Virus[i].name == other.name){
                match = true;
                vName = frontTeethManager.Virus[i].name;
                break;
            }
        }

        if(match){
            if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
                if(vName == other.name)
                    timeStep -= Time.deltaTime;  
            }
        }

        if(timeStep <= 0){
            frontTeethManager.Virus[index].SetActive(false); 
            frontTeethManager.Virus.RemoveAt(index); 
            timeStep = 1.5f;
        }   
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(SinkManager.ToothbrushStep == 1)
            return;
        toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[0];
    }
}
