using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombController : MonoBehaviour
{
    private SpriteRenderer comb;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;    
    private void Start() {
        comb = GetComponent<SpriteRenderer>();
    }
    private void OnMouseUp() {
        if(BathroomManager.BathStep < 8){
            return;
        }
        comb.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(BathroomManager.BathStep < 8 || BathroomManager.BathStep >= 9){
            return;
        }
        comb.sortingOrder = 1;
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
