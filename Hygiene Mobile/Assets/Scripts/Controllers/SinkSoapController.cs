using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkSoapController : MonoBehaviour
{
    private bool collided = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;

    private float timeStep = 2f;
    //private int counter;

    private void OnTriggerStay2D(Collider2D other) {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "RHand" || other.name == "LHand")
                timeStep -= Time.deltaTime;
        }
            
        if(timeStep <= 0){
            if(other.name == "RHand" || other.name == "LHand"){
                collided = true;  
            } 
        }
    }

    private void OnMouseUp() {
        isDragged = false;
        transform.position = spriteDragStartPosition;
        if(collided){
            SinkManager.HandWashStep = 2;
            collided = false;
        }
    }
    private void OnMouseDown() 
    {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
    }
    private void OnMouseDrag() {
        if(SinkManager.HandWashStep != 1)
            return;
        if(isDragged){
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }
}
