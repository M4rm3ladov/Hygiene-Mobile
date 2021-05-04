using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public int tiredTrigger;
    [SerializeField]
    private int hungerTrigger;
    public Animator animTransition;
    [SerializeField]
    private void Start() {
        //play sleepy anim if other animation is playing and if energy is below/equal to alloted thereshold
        //else turn it off
        if((int)Player.Energy <= tiredTrigger && !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Dirty") &&
        !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Hungry"))
        {
            animTransition.SetBool("isSleepy", true);   
        }else{
            animTransition.SetBool("isSleepy", false);
        }  
    }
    private void Update() {
        //play sleepy anim if other animation is playing and if energy is below/equal to alloted thereshold
        //else turn it off
        if((int)Player.Energy <= tiredTrigger && !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Dirty") &&
        !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Hungry"))
        {
            animTransition.SetBool("isSleepy", true);       
        }else{
            animTransition.SetBool("isSleepy", false);
        }
    }
    //wave on character click
    private void OnMouseDown() {
        if(animTransition.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            animTransition.SetTrigger("Wave");
        }      
    }
}
