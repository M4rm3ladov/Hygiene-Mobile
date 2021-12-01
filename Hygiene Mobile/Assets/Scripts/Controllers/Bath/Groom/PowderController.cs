using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderController : MonoBehaviour
{
    [SerializeField]
    List<Sprite> powderSprite = new List<Sprite>();
    public List<Sprite> PowderSprite{
        get{return powderSprite;}
        set{powderSprite = value;}
    }
    private SpriteRenderer powder;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;    
    private void Start() {
        powder = GetComponent<SpriteRenderer>();
    }
    private void OnMouseUp() {
        if(BathroomManager.BathStep < 9){
            return;
        }
        powder.sprite = powderSprite[0];
        powder.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(BathroomManager.BathStep < 9 || BathroomManager.BathStep >= 10){
            return;
        }
        powder.sprite = powderSprite[1];
        powder.sortingOrder = 1;
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
