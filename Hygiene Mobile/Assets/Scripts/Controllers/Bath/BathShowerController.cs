using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathShowerController : MonoBehaviour
{
    [SerializeField]
    BathShampooDispense bathShampooDispense;
    private ParticleSystem showerPs;
    private SpriteRenderer sShower;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;    
    float yAxis;
    private float timeStep = 3f;
    //private int counter;
    private void Start() {
        sShower = GetComponent<SpriteRenderer>();
        showerPs = GetComponentInChildren<ParticleSystem>();
        showerPs.Stop();
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.name != "Hair")
            showerPs.Stop();
    }
    private void OnTriggerStay2D(Collider2D other) {
        //if(Input.touchCount == 1 ) {
        //Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "Hair"){
                showerPs.Play();
                timeStep -= Time.deltaTime;
            }
        //}
        //else
          //  showerPs.Stop();

        if(timeStep <= 0){
            if(other.name == "Hair"){
                if(BathroomManager.BathStep == 4){
                    bathShampooDispense.FadeOutBubbles();
                    BathroomManager.BathStep = 5;
                }else if(BathroomManager.BathStep == 0)
                    BathroomManager.BathStep = 1;
            }
        }
    }
    private void OnMouseUp() {
        //if(BathroomManager.BathStep < 4 && BathroomManager.BathStep != 0){
         //   return;
        //}
        //showerPs.Stop();
        if(BathroomManager.BathStep == 1){
            timeStep = 3f;
        }
        sShower.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(BathroomManager.BathStep > 0 && BathroomManager.BathStep < 4 || BathroomManager.BathStep >= 5){
            return;
            isDragged = false;
        }
        sShower.sortingOrder = 1;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
        yAxis = Input.mousePosition.y;
    }
    private void OnMouseDrag() {
        if(isDragged){
            Vector3 mousePos = new Vector3(Input.mousePosition.x, yAxis, 0f);
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(mousePos) - mouseDragStartPosition);
        }
    }
}
