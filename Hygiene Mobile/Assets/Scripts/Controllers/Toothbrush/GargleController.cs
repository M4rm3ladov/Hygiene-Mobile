using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargleController : MonoBehaviour
{
    [SerializeField]
    MouthManager mouthManager;
    private float timeStep = .7f;
    private void Update() {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if(BrushingManager.ToothbrushStep == 3){
                mouthManager.Mouth[2].SetActive(false);
                mouthManager.Mouth[3].SetActive(true);
                BrushingManager.ToothbrushStep = 4;
            }
        }
    
        if(BrushingManager.ToothbrushStep == 4){
            timeStep -= Time.deltaTime;
        }

        if(timeStep < 0){
            mouthManager.Mouth[3].SetActive(false);
            mouthManager.Mouth[4].SetActive(true);
            BrushingManager.ToothbrushStep = 5;
        }
    }
}
