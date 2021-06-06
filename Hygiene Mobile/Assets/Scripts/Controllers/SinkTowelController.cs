using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkTowelController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer lHand;
    [SerializeField]
    private List<Sprite> lHandList = new List<Sprite>();
    [SerializeField]
    private SpriteRenderer rHand;
    [SerializeField]
    private List<Sprite> rHandList = new List<Sprite>();

    private bool collided = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;

    private float timeStepR = 2f;
    private float timeStepL = 2f;

    private void LateUpdate() {
        if(timeStepR <= 1f && timeStepR >= 0f)
            rHand.sprite = rHandList[1];
        if(timeStepL <= 1f && timeStepL >= 0f)
            lHand.sprite = lHandList[1];

        if(timeStepR < 0 && timeStepL < 0){
            rHand.sprite = rHandList[0];
            lHand.sprite = lHandList[0];
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "RHand")
                timeStepR -= Time.deltaTime;
            else if(other.name == "LHand")
                timeStepL -= Time.deltaTime;
        }
            
        if(timeStepR <= 0 && timeStepL <= 0){
            if(other.name == "RHand" || other.name == "LHand"){
                collided = true;  
                Debug.Log(collided);
            } 
        }
    }
    
    private void OnMouseUp() {
        isDragged = false;
        transform.position = spriteDragStartPosition;
        if(collided)
            SinkManager.HandWashStep = 7;
        Debug.Log(SinkManager.HandWashStep);
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
