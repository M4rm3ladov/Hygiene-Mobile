using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothbrushController : MonoBehaviour
{
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;
    private float timeStep = 2f;

    private void OnMouseUp() {
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
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
