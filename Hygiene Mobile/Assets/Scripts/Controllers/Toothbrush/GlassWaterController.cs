using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWaterController : MonoBehaviour
{
    private bool collided = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;

    private SpriteRenderer gWater;
    [SerializeField]
    private List<Sprite> gSprite = new List<Sprite>();
    [SerializeField]
    MouthManager mouthManager;
    private void Start() {
        gWater = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "tounge"){
            gWater.sprite = gSprite[1];
            BrushingManager.ToothbrushStep = 3;
            mouthManager.Mouth[1].SetActive(false);
            mouthManager.Mouth[2].SetActive(true);
        }    
    }

    private void OnMouseUp() {
        gWater.sortingOrder = 0;
        gWater.sprite = gSprite[0];
        isDragged = false;
        transform.position = spriteDragStartPosition;
        if(collided){
            collided = false;
        }
    }
    private void OnMouseDown() 
    {
        gWater.sortingOrder = 1;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
    }
    private void OnMouseDrag() { 
        if(BrushingManager.ToothbrushStep != 2)
            return; 
        if(isDragged){
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }
}
