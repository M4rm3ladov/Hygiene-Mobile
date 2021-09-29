using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathShampooController : MonoBehaviour
{
    private SpriteRenderer sShampoo;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;    

    //private int counter;
    private void Start() {
        sShampoo = GetComponent<SpriteRenderer>();
    }

    /*private void OnTriggerStay2D(Collider2D other) {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "RHand" || other.name == "LHand")
                timeStep -= Time.deltaTime;
        }
            
        if(timeStep <= 0){
            if(other.name == "RHand" || other.name == "LHand"){
                collided = true;  
            } 
        }
    }*/

    private void OnMouseUp() {
        if(BathroomManager.BathStep < 1){
            return;
        }
        sShampoo.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
        /*if(collided){
            SinkManager.HandWashStep = 2;
            collided = false;
        }*/
    }
    private void OnMouseDown() 
    {
        if(BathroomManager.BathStep < 1 || BathroomManager.BathStep >= 2){
            return;
        }
        sShampoo.sortingOrder = 1;
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
