using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargleController : MonoBehaviour
{
    [SerializeField]
    MouthManager mouthManager;
    private float timeStep = .3f;
    private void Update() {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if(BrushingManager.ToothbrushStep == 3){
                mouthManager.Mouth[2].SetActive(false);
                mouthManager.Mouth[3].SetActive(true);
                FindObjectOfType<AudioManager>().Stop("Gargle");
                BrushingManager.ToothbrushStep = 4;
            }
        }
    
        if(BrushingManager.ToothbrushStep == 4){
            if(timeStep == .5f)
                FindObjectOfType<AudioManager>().Play("Spit");
            timeStep -= Time.deltaTime;
        }

        if(timeStep < 0){
            FindObjectOfType<AudioManager>().Stop("Spit");
            mouthManager.Mouth[3].SetActive(false);
            mouthManager.Mouth[4].SetActive(true);
            BrushingManager.ToothbrushStep = 5;
        }
    }
}
