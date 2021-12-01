using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlushController : MonoBehaviour
{
    private SpriteRenderer sFlush;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;    
    float xAxis;
    //private int counter;
    private void Start() {
        sFlush = GetComponent<SpriteRenderer>();
    }
    /*private void OnTriggerStay2D(Collider2D other) {
        if(BathroomManager.BathStep == 1 || BathroomManager.BathStep == 5)
            return;
  
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "Hair"){
                showerPs.Play();
                timeStep -= Time.deltaTime;
            }
        }
        else
          showerPs.Stop();

        if(timeStep <= 0){
            timeStep = 1f;
                if(BathroomManager.BathStep < 1){
                    BathroomManager.BathStep += .25f;
                    return;
                }
                if(BathroomManager.BathStep == 4.75f)
                    bathShampooDispense.FadeOutBubbles();
                if(BathroomManager.BathStep < 5){
                    BathroomManager.BathStep += .25f;
                }
        }
    }*/
    private void OnMouseUp() {
        if(ToiletManager.ToiletStep < 1){
            return;
        }
        sFlush.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(ToiletManager.ToiletStep < 1 || ToiletManager.ToiletStep >= 2){
            return;
        }
        sFlush.sortingOrder = 2;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
        xAxis = Input.mousePosition.x;
    }
    private void OnMouseDrag() {
        if(isDragged){
            ToiletManager.ToiletStep = 2;
            Vector3 mousePos = new Vector3(xAxis, Input.mousePosition.y, 0f);
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(mousePos) - mouseDragStartPosition);
        }
    }
}
