using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathSoapController : MonoBehaviour
{
    private ParticleSystem bubblePs;
    private SpriteRenderer sSoap;
    private bool collided = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;    

    private float timeStep = 10f;
    //private int counter;
    private void Start() {
        sSoap = GetComponent<SpriteRenderer>();
        bubblePs = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.name != "Body")
            bubblePs.Stop();
    }

    private void OnTriggerStay2D(Collider2D other) {
        //if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "Body"){
                timeStep -= Time.deltaTime;
                bubblePs.Play();
            }
                
        //}else
          // bubblePs.Stop();

        if(timeStep <= 0){
            if(other.name == "Body"){
                BathroomManager.BathStep = 3f;
            } 
        }
    }

    private void OnMouseUp() {
        if(BathroomManager.BathStep < 2){
            //isDragged = false;
            return;
        }
        sSoap.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
        /*if(collided){
            SinkManager.HandWashStep = 2;
            collided = false;
        }*/
    }
    private void OnMouseDown() 
    {
        if(BathroomManager.BathStep < 2 || BathroomManager.BathStep >= 3){
            isDragged = false;
            return;
        }
        sSoap.sortingOrder = 1;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
    }
    private void OnMouseDrag() {
        //if(SinkManager.HandWashStep != 1)
        //    return;
        if(isDragged){
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }
}
