using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    SkinsManager skinsManager;
    [SerializeField]
    private Image hygieneBubble;
    [SerializeField]
    private Image hungerBubble;
    [SerializeField]
    private Image tiredBubble;
    [SerializeField]
    private int hygieneTrigger;
    [SerializeField]
    private int tiredTrigger;
    [SerializeField]
    private int hungerTrigger;
    public int HygieneTrigger{
        get{ return hygieneTrigger; }
        set{ hygieneTrigger = value;}
    }
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
    private float fadingLength = 10f;
    private float currTime;
    
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
        //hungerBubble.CrossFadeAlpha(0, 0.001f, true);
        //hunger
        /*if((int)Player.Hunger <= hungerTrigger &&
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("HungrySleepy") ||
        !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Dirty"))
        {
            animTransition.SetBool("isHungry", true); 

            hungerBubble.enabled = true;  
            hungerBubble.CrossFadeAlpha(0, 0.5f, true);       
        }else{
            animTransition.SetBool("isHungry", false);
        }*/
        if(Player.SleepState == 1)
        {
            PlayStopHygieneAnimation();
            PlayStopHungerAnimation();
            PlayStopSleepyAnimation();
        }
        
        //sleepy
        /*if((int)Player.Energy <= tiredTrigger &&
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("HungrySleepy") ||
        !animTransition.GetCurrentAnimatorStateInfo(0).IsName("Hungry"))
        {
            animTransition.SetBool("isSleepy", true);   
        }else{
            animTransition.SetBool("isSleepy", false);
        } */     
    }
    private void Update() {
        TimeFadeUpdate();
        if(Player.SleepState == 0){
            hygieneBubble.enabled = false;
            tiredBubble.enabled = false;
            hungerBubble.enabled = false;
        }
            
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
        //PlayStopHungerAnimation();
        //sleepy
        //PlayStopSleepyAnimation();    
    }
    private void LateUpdate() {
        if(Player.SleepState == 1){
            PlayStopHygieneAnimation();
            PlayStopHungerAnimation();
            PlayStopSleepyAnimation();    
        }     
    }
    private void TimeFadeUpdate(){
        if (currTime <= 0)
        {
            currTime = fadingLength;
            return;
        }
        currTime -= Time.deltaTime;
    
    }
    private void PlayStopHygieneAnimation(){
        if((int)Player.Hygiene <= hygieneTrigger)//&& 
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("Dirty") && 
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("Wave"))
        {
            skinsManager.Eyebrows.sprite = skinsManager.EyebrowsSpriteOptions[1];
            skinsManager.Mouth.sprite = skinsManager.MouthSpriteOptions[1];
            skinsManager.Mouth.sprite = skinsManager.MouthSpriteOptions[1];
            //animTransition.SetBool("isHungry", true);
            FadeInOutBubble(hygieneBubble);   
            return;    
        }
        //animTransition.SetBool("isHungry", false);
        //hungerBubble.CrossFadeAlpha(0, 0.5f, true);
        hygieneBubble.enabled = false;
    }
    private void PlayStopHungerAnimation(){
        if((int)Player.Hunger <= hungerTrigger && !((int)Player.Hygiene <= hygieneTrigger)) 
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("Dirty") && 
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("Wave"))
        {
            skinsManager.Eyebrows.sprite = skinsManager.EyebrowsSpriteOptions[1];
            skinsManager.Mouth.sprite = skinsManager.MouthSpriteOptions[1];
            skinsManager.Mouth.sprite = skinsManager.MouthSpriteOptions[1];
            //animTransition.SetBool("isHungry", true);
            FadeInOutBubble(hungerBubble);   
            return;    
        }
        //animTransition.SetBool("isHungry", false);
        //hungerBubble.CrossFadeAlpha(0, 0.5f, true);
        hungerBubble.enabled = false;
    }
    private void PlayStopSleepyAnimation(){
        if((int)Player.Energy <= tiredTrigger && !((int)Player.Hunger <= hungerTrigger))
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("Hungry") &&
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("Wave"))
        {
            skinsManager.Eyebrows.sprite = skinsManager.EyebrowsSpriteOptions[1];
            skinsManager.Eyes.sprite = skinsManager.EyesSpriteOptions[2];
            skinsManager.Mouth.sprite = skinsManager.MouthSpriteOptions[1];   
            //animTransition.SetBool("isSleepy", true); 
            //if(Player.SleepState == 1)
            FadeInOutBubble(tiredBubble);
            return;      
        }
        //tiredBubble.CrossFadeAlpha(0, 0.5f, true);
        tiredBubble.enabled = false;
        //animTransition.SetBool("isSleepy", false);
    }
    private void FadeInOutBubble(Image bubble)
    {
        
        if(currTime < 5f){
            bubble.enabled = true;
            //bubble.CrossFadeAlpha(0, 0.5f, true);
            return;
        }          
        //if(currTime <= 10f && currTime >= 5f){
        bubble.enabled = false; 
        //bubble.CrossFadeAlpha(1, 0.5f, true);
    }
    //wave on character click
    private void OnMouseDown() {
        if(animTransition.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            animTransition.SetTrigger("Wave");
        }      
    }
}
