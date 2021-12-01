using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkSoapController : MonoBehaviour
{
    private SpriteRenderer sSoap;
    //private bool collided = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;   
    private ParticleSystem bubblePs; 

    private float timeStep = 1.5f;
    //private int counter;
    private void Start() {
        sSoap = GetComponent<SpriteRenderer>();
        bubblePs = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.name != "RHand" || other.name != "LHand")
            bubblePs.Stop();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(SinkManager.HandWashStep == 2){
            sSoap.sortingOrder = 4;
            isDragged = false;
            transform.position = spriteDragStartPosition;
            return;
        }
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "RHand" || other.name == "LHand"){
                bubblePs.Play();
                timeStep -= Time.deltaTime;
            }
            else
                bubblePs.Stop();
        }
            
        if(timeStep <= 0){
            if(other.name == "RHand" || other.name == "LHand"){
                timeStep = 1.5f;
                SinkManager.HandWashStep += .25f;
                //collided = true;  
            } 
        }
    }

    private void OnMouseUp() {
        if(SinkManager.HandWashStep < 1){
            return;
        }
        sSoap.sortingOrder = 4;
        isDragged = false;
        transform.position = spriteDragStartPosition;
        /*if(collided){
            SinkManager.HandWashStep = 2;
            collided = false;
        }*/
    }
    private void OnMouseDown() 
    {
        if(SinkManager.HandWashStep < 1 || SinkManager.HandWashStep >= 2){
            return;
        }
        sSoap.sortingOrder = 5;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
    }
    private void OnMouseDrag() {
        if(SinkManager.HandWashStep == 2){
            sSoap.sortingOrder = 4;
            isDragged = false;
            transform.position = spriteDragStartPosition;
            return;
        }
        //if(SinkManager.HandWashStep != 1)
        //    return;
        if(isDragged){
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }
}
