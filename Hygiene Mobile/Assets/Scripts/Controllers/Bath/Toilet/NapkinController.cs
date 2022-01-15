using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapkinController : MonoBehaviour
{  
    [SerializeField]
    GameObject crumpledP;
    Animator crumpledPAnim;
    private SpriteRenderer sNapkin;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false; 
    private float timeStep = 1f;
    private bool collided = false;
    private Color c;

    private void Start() {
        sNapkin = GetComponent<SpriteRenderer>();
        crumpledPAnim = GetComponent<Animator>();
        c = sNapkin.material.color;
    }
    private void Update() {
        if(collided)
            timeStep -= Time.deltaTime;
            if(timeStep <= 0){
                c.a = 1f;
                sNapkin.material.color = c;

                timeStep = 1;
                crumpledP.SetActive(false);
                collided = false;
            }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(ToiletManager.ToiletStep >= 3)
            return;
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if("Body" == other.name){
                ToiletManager.ToiletStep += .5f; 
                transform.position = spriteDragStartPosition;
                sNapkin.sortingOrder = 0;
                isDragged = false;
                crumpledP.SetActive(true);
                collided = true;

                c.a = 0f;
                sNapkin.material.color = c;
            }
        }
    }

    private void OnMouseUp() {
        if(ToiletManager.ToiletStep < 2){
            return;
        }
        sNapkin.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(ToiletManager.ToiletStep < 2 || ToiletManager.ToiletStep >= 3){
            return;
        }
        sNapkin.sortingOrder = 2;
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
