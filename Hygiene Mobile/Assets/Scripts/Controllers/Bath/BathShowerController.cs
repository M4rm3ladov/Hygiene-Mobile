﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathShowerController : MonoBehaviour
{
    private ParticleSystem showerPs;
    private SpriteRenderer sShower;
    private bool collided = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;    
    float yAxis;

    private float timeStep = 2f;
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
        if(Input.touchCount == 1 ) {
        //Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "Hair")
                showerPs.Play();
        }
        else
            showerPs.Stop();
    }
    private void OnMouseUp() {
        //showerPs.Stop();
        sShower.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
        /*if(collided){
            SinkManager.HandWashStep = 2;
            collided = false;
        }*/
    }
    private void OnMouseDown() 
    {
        sShower.sortingOrder = 1;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
        yAxis = Input.mousePosition.y;
    }
    private void OnMouseDrag() {
        //if(SinkManager.HandWashStep != 1)
        //    return;
        if(isDragged){
            //transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
            Vector3 mousePos = new Vector3(Input.mousePosition.x, yAxis, 0f);
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(mousePos) - mouseDragStartPosition);
        }
    }
}
