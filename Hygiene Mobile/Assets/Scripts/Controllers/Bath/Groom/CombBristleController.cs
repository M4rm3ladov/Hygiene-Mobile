using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombBristleController : MonoBehaviour
{
    private float timeStep = .75f;

    private void OnTriggerStay2D(Collider2D other) {
        if(BathroomManager.BathStep == 9)
            return;

            //if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
                if(other.name == "Hair")
                    timeStep -= Time.deltaTime;  
            //}
        

        if(timeStep <= 0){ 
            timeStep = .75f;
            BathroomManager.BathStep += .125f;
        }
    }
}
