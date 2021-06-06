using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkFaucetController : MonoBehaviour
{
    //[SerializeField]
    //private List<GameObject> virus = new List<GameObject>();

    [SerializeField]
    private Animator faucetWater;
    [SerializeField]
    private GameObject water;
    private bool fSwitch = false;

    [SerializeField]
    private Animator rHand;
    [SerializeField]
    private Animator lHand;
    private float timeStep = 1.7f;
    private int counter;

    void Update()
    {
        if(SinkManager.HandWashStep != 4)
            return;

        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
            StopAnimation();

        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
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
                //virus[0].SetActive(false);
                //virus[4].SetActive(false);
                rHand.SetInteger("Palm", 0);
                lHand.SetInteger("Palm", 1);
                break;
            case 1:
                //virus[1].SetActive(false);
                //virus[5].SetActive(false);
                rHand.SetInteger("Palm", 1);
                lHand.SetInteger("Palm", 0);
                break;
            case 2:
                //virus[2].SetActive(false);
                //virus[6].SetActive(false);
                rHand.SetInteger("Back", 0);
                lHand.SetInteger("Back", 1);
                break;
            case 3:
                //virus[3].SetActive(false);
                //virus[7].SetActive(false);
                rHand.SetInteger("Back", 1);
                lHand.SetInteger("Back", 0);
                break;
            case 4:
                StopAnimation();
                SinkManager.HandWashStep = 5;
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
                rHand.SetInteger("Back", -1);
                lHand.SetInteger("Back", -1);
                break;
            case 3:
                rHand.SetInteger("Back", -1);
                lHand.SetInteger("Back", -1);
                break;
            default:
                DefaultAnim();
                break;
        }
    }
    void DefaultAnim(){
        rHand.SetInteger("Palm", 0);
        lHand.SetInteger("Palm", 0);
        rHand.SetInteger("Back", -1);
        lHand.SetInteger("Back", -1);
    }

    private void OnMouseDown() {
        Debug.Log(SinkManager.HandWashStep);
        if(SinkManager.HandWashStep > 0 && SinkManager.HandWashStep < 3 || SinkManager.HandWashStep > 5)
            return;
        
        if(!fSwitch){
            fSwitch = true;
            water.SetActive(true);
            if(SinkManager.HandWashStep >= 3)
                SinkManager.HandWashStep = 4;
            
            return;
        }
        if(SinkManager.HandWashStep == 4)
            return;

        fSwitch = false;  
        water.SetActive(false);
        if(SinkManager.HandWashStep == 5){
            SinkManager.HandWashStep = 6;
            return;
        }

        SinkManager.HandWashStep = 1;
    }
}
