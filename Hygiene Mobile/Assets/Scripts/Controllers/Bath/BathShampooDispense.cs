using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathShampooDispense : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer leftSbubble;
    [SerializeField]
    SpriteRenderer rightSbubble; 
    private bool LTrigger, RTrigger;
    private void Start() {
        Color lB = leftSbubble.material.color;
        lB.a = 0f;
        leftSbubble.material.color = lB;

        Color rB = rightSbubble.material.color;
        rB.a = 0f;
        rightSbubble.material.color = rB;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "leftH"){// || other.name == "LHand")
                if(!LTrigger){
                    StartCoroutine(FadeIn(leftSbubble));
                    LTrigger = true;
                }
            }
            if(other.name == "rightH"){
                if(!RTrigger){
                    StartCoroutine(FadeIn(rightSbubble));
                    RTrigger = true;
                }
            }
        }
           
    }
    IEnumerator FadeIn(SpriteRenderer part){
        for(float f = 0.05f; f<=1; f+=0.05f){
            Color c = part.material.color;
            c.a = f;
            part.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    
}
