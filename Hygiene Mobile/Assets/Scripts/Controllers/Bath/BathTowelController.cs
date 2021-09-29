using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathTowelController : MonoBehaviour
{
    [SerializeField]
    private GameObject Bg1;
    [SerializeField]
    private GameObject Bg2;
    [SerializeField]
    private GameObject Boy;
    [SerializeField]
    private GameObject Girl;
    private SpriteRenderer sTowel;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;    
    private float timeStep = .75f;
    private void Start() {
        sTowel = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(BathroomManager.BathStep == 6)
            return;
        //if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "Body")
                timeStep -= Time.deltaTime;
        //}
            
        if(timeStep <= 0){  
            timeStep = .75f;
            BathroomManager.BathStep += .25f; 
        }
    }

    private void OnMouseUp() {
        if(BathroomManager.BathStep < 5){
            return;
        }
        if(BathroomManager.BathStep == 6){
            if(PlayerPrefs.GetInt("gender") == 0)
                Boy.SetActive(false);
            else if(PlayerPrefs.GetInt("gender") == 1)
                Girl.SetActive(false);
            Bg2.SetActive(true);
            Bg1.SetActive(false);
        }
        sTowel.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(BathroomManager.BathStep < 5){
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
