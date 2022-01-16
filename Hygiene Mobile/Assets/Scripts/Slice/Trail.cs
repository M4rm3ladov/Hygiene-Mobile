using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;
    //private Vector2 mousePos;
    private float distance = 10;
    private void Start() {
        particle.SetActive(false);
    }
    private void Update() {
        if(Time.timeScale == 0)
            return;
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            particle.SetActive(true);
        }else{
            particle.SetActive(false);
        }
        /*if(Input.GetMouseButtonDown(0))
        {
            particle.SetActive(true);
        }*/
            Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Vector3 pos = mousePos.GetPoint(distance);
            particle.transform.position = pos;
       //}
        /*if(Input.GetMouseButtonUp(0)){
            particle.SetActive(false);
        }*/
    }

    
}
