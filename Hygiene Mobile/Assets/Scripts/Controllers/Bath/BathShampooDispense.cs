using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathShampooDispense : MonoBehaviour
{
    private ParticleSystem shampooPs;
    private void Start() {
        shampooPs = GetComponentInChildren<ParticleSystem>();
        shampooPs.Stop();
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.name != "Hair")
            shampooPs.Stop();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "Hair")// || other.name == "LHand")
                shampooPs.Play();
        }else
            shampooPs.Stop();
    }
}
