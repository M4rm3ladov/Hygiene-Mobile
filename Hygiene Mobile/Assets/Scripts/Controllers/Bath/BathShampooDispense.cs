using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathShampooDispense : MonoBehaviour
{
    GameObject[] Hair = new GameObject[5];
    SpriteRenderer leftSbubble;
    SpriteRenderer rightSbubble;
    private bool LTrigger, RTrigger;
    private void Start() {
        leftSbubble = GameObject.Find("bubbleShampoo2").GetComponent<SpriteRenderer>();
        rightSbubble = GameObject.Find("bubbleShampoo").GetComponent<SpriteRenderer>();
        
        for (int i = 0; i < 5; i++)
        {
            Hair[i] = GameObject.Find("Hair").transform.GetChild(i).gameObject;
        }

        Color lB = leftSbubble.material.color;
        lB.a = 0f;
        leftSbubble.material.color = lB;

        Color rB = rightSbubble.material.color;
        rB.a = 0f;
        rightSbubble.material.color = rB;
    }
    private void Update() {
        if(BathroomManager.BathStep == 2)
            foreach (var item in Hair)
            {
                item.SetActive(false);
            }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(other.name == "leftH"){// || other.name == "LHand")
                if(!LTrigger){
                    StartCoroutine(FadeIn(leftSbubble));
                    LTrigger = true;
                    BathroomManager.BathStep += .5f;
                }
            }else if(other.name == "rightH"){
                if(!RTrigger){
                    StartCoroutine(FadeIn(rightSbubble));
                    RTrigger = true;
                    BathroomManager.BathStep += .5f;
                }
            }
        //}
           
    }
    public void FadeOutBubbles(){
        StartCoroutine(FadeOut(rightSbubble));
        StartCoroutine(FadeOut(leftSbubble));
    }
    IEnumerator FadeIn(SpriteRenderer part){
        for(float f = 0.05f; f<=1; f+=0.05f){
            Color c = part.material.color;
            c.a = f;
            part.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator FadeOut(SpriteRenderer part){
        for(float f = 1f; f>=-.05f; f-=0.05f){
            Color c = part.material.color;
            c.a = f;
            part.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    
}
