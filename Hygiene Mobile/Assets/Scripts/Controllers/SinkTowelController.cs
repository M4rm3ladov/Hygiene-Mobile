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
    private SpriteRenderer sTowel;

    //private bool collided = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;

    private float timeStepR = 1f;
    private float timeStepL = 1f;
    private int RTrigger = 0;
    private int LTrigger = 0;
    private void Start() {
        sTowel = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate() {
        if(RTrigger == 1){
            rHand.sprite = rHandList[1];
        }
        if(LTrigger == 1)
            lHand.sprite = lHandList[1];
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "RHand")
                timeStepR -= Time.deltaTime;
            if(other.name == "LHand")
                timeStepL -= Time.deltaTime;
        }
        if(RTrigger < 2){
            if(timeStepR <= 0 )
            {
                timeStepR = 1;
                SinkManager.HandWashStep += .25f;
                RTrigger += 1;
            }
        }
        if(LTrigger < 2){
            if(timeStepL <= 0 )
            {
                timeStepL = 1;
                SinkManager.HandWashStep += .25f;
                LTrigger += 1;
            }
        }
         
    }
    
    private void OnMouseUp() {
        if(SinkManager.HandWashStep < 6){
            return;
        }
        sTowel.sortingOrder = 4;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(SinkManager.HandWashStep < 6 || SinkManager.HandWashStep == 7){
            return;
        }
        sTowel.sortingOrder = 5;
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
