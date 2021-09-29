using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipperController : MonoBehaviour
{
    [SerializeField]
    GameObject Bg3;
    [SerializeField]
    GenderLoad genderLoad;
    [SerializeField]
    GameObject Feet;
    [SerializeField]
    List<Sprite> clipperSprite = new List<Sprite>(); 
    private SpriteRenderer clipper;
    NailsManager nailsManager;
    Animator clipperA;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool isDragged = false;   
    private void Start() {
        clipperA = GetComponentInChildren<Animator>();
        nailsManager = GetComponentInChildren<NailsManager>();
        clipper = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUp() {
        if(BathroomManager.BathStep < 7){
            return;
        }
        if(nailsManager.Nails.Count == 10){
            GameObject.Find("Hands").SetActive(false);
            Feet.SetActive(true);
            clipperA.enabled = false;
        }
        if(nailsManager.Nails.Count == 0){
            clipperA.enabled = false;
            GameObject.Find("Bg2").SetActive(false);
            Bg3.SetActive(true);
            if(PlayerPrefs.GetInt("gender") == 0)
                genderLoad.Boy.SetActive(true);
            else if(PlayerPrefs.GetInt("gender") == 1)
                genderLoad.Girl.SetActive(true);
        }
        clipper.sprite = clipperSprite[0];
        clipper.sortingOrder = 0;
        isDragged = false;
        transform.position = spriteDragStartPosition;
    }
    private void OnMouseDown() 
    {
        if(BathroomManager.BathStep < 7 || BathroomManager.BathStep >= 8){
            return;
        }
        clipper.sprite = clipperSprite[1];
        clipper.sortingOrder = 1;
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
