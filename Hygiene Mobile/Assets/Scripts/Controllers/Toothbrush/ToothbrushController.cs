using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothbrushController : MonoBehaviour
{
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;
    private SpriteRenderer toothB;
    [SerializeField]
    ToothbrushManager toothbrushManager;
    private void Start() {
        toothB = GetComponent<SpriteRenderer>();
    }
    private void OnMouseUp() {
        toothB.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
        if(BrushingManager.ToothbrushStep == 1)
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[1];
        if(BrushingManager.ToothbrushStep > 1)
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[0];
    }
    private void OnMouseDown() 
    {
        toothB.sortingOrder = 1;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
    }
    private void OnMouseDrag() { 
        if(BrushingManager.ToothbrushStep > 3 || BrushingManager.ToothbrushStep < 1)
            return;
        if(isDragged){
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }
}
