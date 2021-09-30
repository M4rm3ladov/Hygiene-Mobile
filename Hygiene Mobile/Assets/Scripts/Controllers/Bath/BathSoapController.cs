using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathSoapController : MonoBehaviour
{
    private ParticleSystem bubblePs;
    private SpriteRenderer sSoap;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;    
    private float timeStep = 1.5f;
    private void Start() {
        sSoap = GetComponent<SpriteRenderer>();
        bubblePs = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.name != "Body")
            bubblePs.Stop();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(BathroomManager.BathStep == 3)
            return;
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "Body"){
                timeStep -= Time.deltaTime;
                bubblePs.Play();
            }
                
        }else
          bubblePs.Stop();

        if(timeStep <= 0){
            timeStep = 1.5f;
            BathroomManager.BathStep += .25f;
        }
    }

    private void OnMouseUp() {
        if(BathroomManager.BathStep < 2){
            return;
        }
        sSoap.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(BathroomManager.BathStep < 2 || BathroomManager.BathStep >= 3){
            return;
        }
        sSoap.sortingOrder = 1;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
    }
    private void OnMouseDrag() {
        if(isDragged){
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }
}
