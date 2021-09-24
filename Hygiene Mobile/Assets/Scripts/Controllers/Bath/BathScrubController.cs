using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathScrubController : MonoBehaviour
{
     private List<GameObject> virus = new List<GameObject>();    private SpriteRenderer sScrub;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false; 
    private bool match = false;   
    private string vName;
    private int index;
    private float addend = .125f;

    private float timeStep = 2f;
    //private int counter;
    private void Start() {
        sScrub = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 8; i++)
        {
            virus.Add(GameObject.Find("Body").transform.GetChild(i).gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        for (int i = 0; i < virus.Count; i++)
        {
            index = i;
            if(virus[i].name == other.name){
                match = true;
                vName = virus[i].name;
                break;
            }
        }

        if(match){
            //if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
                if(vName == other.name)
                    timeStep -= Time.deltaTime;  
            //}
        }

        if(timeStep <= 0){
            virus[index].SetActive(false); 
            virus.RemoveAt(index); 
            timeStep = 1.5f;
            BathroomManager.BathStep += addend; 
        }
    }

    private void OnMouseUp() {
        if(BathroomManager.BathStep < 3){
            return;
        }
        sScrub.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(BathroomManager.BathStep < 3 || BathroomManager.BathStep >= 4){
            isDragged = false;
            return;
        }
        sScrub.sortingOrder = 1;
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
