using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderDispenseController : MonoBehaviour
{
    private ParticleSystem powderPs;
    private float timeStep = .75f;
    private void Start() {
        powderPs = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.name != "Body"){
            powderPs.Stop();
            FindObjectOfType<AudioManager>().Stop("Powder");
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Body")
            FindObjectOfType<AudioManager>().Play("Powder");
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(BathroomManager.BathStep == 10){
            return;
        }
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began){
            if(other.name == "Body"){
                FindObjectOfType<AudioManager>().Play("Powder");
            }
        }
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "Body"){
                powderPs.Play();
                timeStep -= Time.deltaTime;  
            }
        }
        if(timeStep <= 0){ 
            timeStep = .75f;
            BathroomManager.BathStep += .125f;
        }
    }
}
