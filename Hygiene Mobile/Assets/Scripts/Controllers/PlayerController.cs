using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int tiredTrigger;
    [SerializeField]
    private int hungerTrigger;
    public int TiredTrigger{
        get{ return tiredTrigger; }
        set{ tiredTrigger = value;}
    }
    public int HungerTrigger{
        get{ return hungerTrigger; }
        set{ hungerTrigger = value;}
    }
    [SerializeField]
    private Animator animTransition;
    public Animator AnimTransition{
        get{ return animTransition; }
        set{ animTransition = value; }
    }
    
    private void Start() {
        //play sleepy anim if other animation is playing and if energy is below/equal to alloted thereshold
        //else turn it off
                //huger and sleepy
        /*if((int)Player.Hunger <= hungerTrigger && (int)Player.Energy <= tiredTrigger)
        {
            animTransition.SetBool("isHungrySleepy", true);   
        }else{
            animTransition.SetBool("isHungrySleepy", false);
        }*/
        //hunger
        if((int)Player.Hunger <= hungerTrigger &&
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("HungrySleepy") ||
        !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Dirty"))
        {
            animTransition.SetBool("isHungry", true);   
        }else{
            animTransition.SetBool("isHungry", false);
        }
        //sleepy
        if((int)Player.Energy <= tiredTrigger &&
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("HungrySleepy") ||
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
        /*if((int)Player.Energy <= tiredTrigger && (int)Player.Hunger <= hungerTrigger &&
        !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Wave"))
        {
            animTransition.SetBool("isHungrySleepy", true);       
        }else{
            animTransition.SetBool("isHungrySleepy", false);
        }*/
        //hunger
        if((int)Player.Hunger <= hungerTrigger &&
        !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Dirty") &&
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("HungrySleepy") ||  
        !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Wave"))
        {
            animTransition.SetBool("isHungry", true);       
        }else{
            animTransition.SetBool("isHungry", false);
        }
        //sleepy
        if((int)Player.Energy <= tiredTrigger &&
        !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Hungry") &&
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("HungrySleepy") ||
        !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Wave"))
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
