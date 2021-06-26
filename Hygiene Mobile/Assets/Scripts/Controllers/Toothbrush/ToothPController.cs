using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothPController : MonoBehaviour
{
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;

    private SpriteRenderer toothP;
    private void Start() {
        toothP = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUp() {
        toothP.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        toothP.sortingOrder = 1;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
    }
    private void OnMouseDrag() { 
        if(BrushingManager.ToothbrushStep > 1)
           return;
        if(isDragged){
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }
}
