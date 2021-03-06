using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BristleController : MonoBehaviour
{
    [SerializeField]
    MouthManager mouthManager;
    [SerializeField]
    ToothbrushManager toothbrushManager;
    [SerializeField]
    VirusManager virusManager;
    [SerializeField]
    VirusManager virusManager2;
    private float timeStep = 1.5f;
    private bool match = false;
    private  string vName;
    private int index;
    private float addend = 0.047f;
    private void OnTriggerEnter2D(Collider2D other) {
        timeStep = 1.5f;
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(mouthManager.Mouth[0].activeSelf){
            PlayFrontTeethMecanics(other);

            if(virusManager.Virus.Count == 0){
                mouthManager.Mouth[0].SetActive(false);
                toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[0];
                mouthManager.Mouth[1].SetActive(true); 
            }
        }else if(mouthManager.Mouth[1].activeSelf){
            PlayMouthOpenMechanics(other);

            if(virusManager2.Virus.Count == 0){
                BrushingManager.ToothbrushStep = 2;
            }
        }
           
    }

    private void OnTriggerExit2D(Collider2D other) {
        /*if(SinkManager.ToothbrushStep == 1)
            return;
        toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[0];*/
    }

    private void PlayFrontTeethMecanics(Collider2D other){
        if(other.name == "top" || other.name == "bottom"){
            //BrushingManager.ToothbrushStep = 2;
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[2];
        }
        if(other.name == "topL" || other.name == "bottomL"){
            //BrushingManager.ToothbrushStep = 2;
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[4];
        }
        if(other.name == "topR" || other.name == "bottomR"){
            //BrushingManager.ToothbrushStep = 2;
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[3];
        }

        RemoveVirus(virusManager, other);
    }
    private void PlayMouthOpenMechanics(Collider2D other){
        if(other.name == "tounge" || other.name == "molarTopL" || other.name == "molarTopR" || 
            other.name == "molarBotL" || other.name == "molarBotR"){
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[2];
        }
        if(other.name == "cheekL"){
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[3];
        }
        if(other.name == "cheekR"){
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[4];
        }

        RemoveVirus(virusManager2, other);
    }
    private void RemoveVirus(VirusManager v, Collider2D other){            
        for (int i = 0; i < v.Virus.Count; i++)
        {
            index = i;
            if(v.Virus[i].name == other.name){
                match = true;
                vName = v.Virus[i].name;
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
            v.Virus[index].SetActive(false); 
            v.Virus.RemoveAt(index); 
            timeStep = 1.5f;
            BrushingManager.ToothbrushStep += addend; 
            Debug.Log(BrushingManager.ToothbrushStep);
        }
    }
}
