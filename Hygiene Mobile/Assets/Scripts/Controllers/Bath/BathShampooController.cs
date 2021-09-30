using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathShampooController : MonoBehaviour
{
    private SpriteRenderer sShampoo;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;    

    private void Start() {
        sShampoo = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUp() {
        if(BathroomManager.BathStep < 1){
            return;
        }
        sShampoo.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
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
