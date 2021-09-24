using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathTowelController : MonoBehaviour
{
    private SpriteRenderer sTowel;
    private bool collided = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;    

    private float timeStep = 2f;
    //private int counter;
    private void Start() {
        sTowel = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        //if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "Body")
                timeStep -= Time.deltaTime;
        //}
            
        if(timeStep <= 0){
            if(other.name == "Body"){
                BathroomManager.BathStep = 6; 
            } 
        }
    }

    private void OnMouseUp() {
        if(BathroomManager.BathStep < 5){
            return;
        }
        sTowel.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(BathroomManager.BathStep < 5){
            isDragged = false;
            return;
        }
        sTowel.sortingOrder = 1;
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
