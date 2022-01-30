using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWashController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> virus = new List<GameObject>();

    [SerializeField]
    private Animator rHand;
    [SerializeField]
    private Animator lHand;
    private float timeStep = 1.7f;
    private int counter;
    private bool washing = true;

    void Update()
    {
        if(SinkManager.HandWashStep < 2 || SinkManager.HandWashStep >= 3){
            FindObjectOfType<AudioManager>().Stop("Hand");
            return;
        }

        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended){
            washing = true;
            FindObjectOfType<AudioManager>().Stop("Hand");
            StopAnimation();
        }

        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(washing == true){
                FindObjectOfType<AudioManager>().Play("Hand");
                washing = false;
            }
            PlayAnimation();
            timeStep -= Time.deltaTime;
        }
            
        if(timeStep <= 0){
            StopAnimation();
            counter++;
            timeStep = 1.7f; 
        }
    }

    void PlayAnimation(){
        switch (counter)
        {
            case 0:
                SinkManager.HandWashStep = 2.083f;
                rHand.SetInteger("Palm", 0);
                lHand.SetInteger("Palm", 1);
                break;
            case 1:
                SinkManager.HandWashStep = 2.166f;
                rHand.SetInteger("Palm", 1);
                lHand.SetInteger("Palm", 0);
                break;
            case 2:
                SinkManager.HandWashStep = 2.249f;
                rHand.SetInteger("Thumb", 0);
                lHand.SetInteger("Thumb", 1);
                break;
            case 3:
                SinkManager.HandWashStep = 2.332f;
                rHand.SetInteger("Thumb", 1);
                lHand.SetInteger("Thumb", 0);
                break;
            case 4:
                SinkManager.HandWashStep = 2.415f;
                virus[2].SetActive(false);
                rHand.SetInteger("Fingernail", 0);
                lHand.SetInteger("Fingernail", 1);
                break;
            case 5:
                SinkManager.HandWashStep = 2.498f;
                virus[6].SetActive(false);
                rHand.SetInteger("Fingernail", 1);
                lHand.SetInteger("Fingernail", 0);
                break;
            case 6:
                SinkManager.HandWashStep = 2.581f;
                virus[3].SetActive(false);
                rHand.SetInteger("Back", 0);
                lHand.SetInteger("Back", 1);
                break;
            case 7:
                SinkManager.HandWashStep = 2.664f;
                virus[7].SetActive(false);
                rHand.SetInteger("Back", 1);
                lHand.SetInteger("Back", 0);
                break;
            case 8:
                SinkManager.HandWashStep = 2.747f;
                virus[4].SetActive(false);
                rHand.SetInteger("Wrist", 0);
                lHand.SetInteger("Wrist", 1);
                break;
            case 9:
                SinkManager.HandWashStep = 2.83f;
                virus[0].SetActive(false);
                rHand.SetInteger("Wrist", 1);
                lHand.SetInteger("Wrist", 0);
                break;
            case 10:
                SinkManager.HandWashStep = 2.913f;
                virus[5].SetActive(false);
                rHand.SetInteger("Back", 0);
                lHand.SetInteger("Between", 1);
                break;
            case 11:
                SinkManager.HandWashStep = 2.996f;
                virus[1].SetActive(false);
                rHand.SetInteger("Back", -1);
                rHand.SetInteger("Between", 1);
                lHand.SetInteger("Back", 0);
                break;
            case 12:
                SinkManager.HandWashStep = 3;
                StopAnimation();
                break;
            
            default:
                DefaultAnim();
                break;
        }
    }
    void StopAnimation(){
        switch (counter)
        {
            case 0:
                rHand.SetInteger("Palm", 0);
                lHand.SetInteger("Palm", 0);
                break;
            case 1:
                rHand.SetInteger("Palm", 0);
                lHand.SetInteger("Palm", 0);
                break;
            case 2:
                rHand.SetInteger("Thumb", -1);
                lHand.SetInteger("Thumb", -1);
                break;
            case 3:
                rHand.SetInteger("Thumb", -1);
                lHand.SetInteger("Thumb", -1);
                break;
            case 4:
                rHand.SetInteger("Fingernail", 0);
                lHand.SetInteger("Fingernail", 0);
                break;
            case 5:
                rHand.SetInteger("Fingernail", 0);
                lHand.SetInteger("Fingernail", 0);
                break;
            case 6:
                rHand.SetInteger("Back", -1);
                lHand.SetInteger("Back", -1);
                break;
            case 7:
                rHand.SetInteger("Back", -1);
                lHand.SetInteger("Back", -1);
                break;
            case 8:
                rHand.SetInteger("Wrist", -1);
                lHand.SetInteger("Wrist", -1);
                break;
            case 9:
                rHand.SetInteger("Wrist", -1);
                lHand.SetInteger("Wrist", -1);
                break;
            case 10:
                rHand.SetInteger("Between", -1);
                lHand.SetInteger("Between", -1);
                break;
            case 11:
                rHand.SetInteger("Between", -1);
                lHand.SetInteger("Between", -1);
                break;
            default:
                DefaultAnim();        
                break;
        }
    }
    private void DefaultAnim(){
        rHand.SetInteger("Palm", 0);
        lHand.SetInteger("Palm", 0);
        rHand.SetInteger("Thumb", -1);
        lHand.SetInteger("Thumb", -1);
        rHand.SetInteger("Fingernail", 0);
        lHand.SetInteger("Fingernail", 0);
        rHand.SetInteger("Back", -1);
        lHand.SetInteger("Back", -1);
        rHand.SetInteger("Between", -1);
        lHand.SetInteger("Between", -1);
        rHand.SetInteger("Wrist", -1);
        lHand.SetInteger("Wrist", -1);
    }
}
