﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWashController : MonoBehaviour
{
    [SerializeField]
    private Animator rHand;
    [SerializeField]
    private Animator lHand;
    private float timeStep = 1.7f;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            PlayAnimation();
            timeStep -= Time.deltaTime;
        }
            
        else if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
            StopAnimation();

        if(timeStep <= 0){
            StopAnimation();
            counter++;
            timeStep = 1.7f; 
        }
    }

    void PlayAnimation(){
        Debug.Log(counter);
        switch (counter)
        {
            case 0:
                rHand.SetInteger("Palm", 0);
                lHand.SetInteger("Palm", 1);
                break;
            case 1:
                rHand.SetInteger("Palm", 1);
                lHand.SetInteger("Palm", 0);
                break;
            case 2:
                rHand.SetInteger("Thumb", 0);
                lHand.SetInteger("Thumb", 1);
                break;
            case 3:
                rHand.SetInteger("Thumb", 1);
                lHand.SetInteger("Thumb", 0);
                break;
            case 4:
                rHand.SetInteger("Fingernail", 0);
                lHand.SetInteger("Fingernail", 1);
                break;
            case 5:
                rHand.SetInteger("Fingernail", 1);
                lHand.SetInteger("Fingernail", 0);
                break;
            case 6:
                rHand.SetInteger("Back", 0);
                lHand.SetInteger("Back", 1);
                break;
            case 7:
                rHand.SetInteger("Back", 1);
                lHand.SetInteger("Back", 0);
                break;
            case 8:
                rHand.SetInteger("Wrist", 0);
                lHand.SetInteger("Wrist", 1);
                break;
            case 9:
                rHand.SetInteger("Wrist", 1);
                lHand.SetInteger("Wrist", 0);
                break;
            case 10:
                rHand.SetInteger("Back", 0);
                lHand.SetInteger("Between", 1);
                break;
            case 11:
                rHand.SetInteger("Back", -1);
                rHand.SetInteger("Between", 1);
                lHand.SetInteger("Back", 0);
                break;
            
            default:
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
                break;
        }
    }
}