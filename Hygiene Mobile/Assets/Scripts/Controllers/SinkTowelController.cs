using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkTowelController : MonoBehaviour
{
    private bool collided = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;
    
    private void OnMouseUp() {
        isDragged = false;
        transform.position = spriteDragStartPosition;
        if(collided)
            SinkManager.HandWashStep = 2;
    }
    private void OnMouseDown() 
    {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
    }
    private void OnMouseDrag() {
        if(SinkManager.HandWashStep != 6)
            return;
        if(isDragged){
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }
}
