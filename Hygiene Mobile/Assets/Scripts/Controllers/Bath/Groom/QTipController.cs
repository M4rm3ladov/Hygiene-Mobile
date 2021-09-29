using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTipController : MonoBehaviour
{ 
    [SerializeField]
    GameObject Hands;
    private SpriteRenderer qTip;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;  

    private void Start() {
        qTip = GetComponent<SpriteRenderer>();
    }
    private void OnMouseUp() {
        Debug.Log(BathroomManager.BathStep);
        if(BathroomManager.BathStep < 6)
            return;
        if(BathroomManager.BathStep == 7){
            GameObject.Find("faceSprite").SetActive(false);
            Hands.SetActive(true);
        }
        /*if(BathroomManager.BathStep < 5){
            return;
        }*/
        qTip.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(BathroomManager.BathStep < 6 || BathroomManager.BathStep >= 7){
            isDragged = false;
            return;
        }
        qTip.sortingOrder = 1;
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
