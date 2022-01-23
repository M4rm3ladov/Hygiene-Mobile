using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    SkinsManager skinsManager;
    [SerializeField]
    private Image handWashBubble;
    [SerializeField]
    private Image toiletBubble;
    [SerializeField]
    private Image hygieneBubble;
    [SerializeField]
    private Image hungerBubble;
    [SerializeField]
    private Image tiredBubble;

    [SerializeField]
    private double toiletTrigger;
    [SerializeField]
    private int hygieneTrigger;
    [SerializeField]
    private int tiredTrigger;
    [SerializeField]
    private int hungerTrigger;
    public double ToiletTrigger{
        get{ return toiletTrigger; }
        set{ toiletTrigger = value;}
    }
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
    private TimeSpan _timeDifference;
    
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
        _timeDifference = DateTime.Now - DateTime.Parse(Player.LastAte); //- Player.LastAte;
        //Debug.Log(_timeDifference.TotalMinutes);
        if(Player.SleepState == 1)
        {
            PlayStopToiletAnimation();
            PlayStopHygieneAnimation();
            PlayStopHungerAnimation();
            PlayStopHandWashAnimation();
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
        _timeDifference = DateTime.Now - DateTime.Parse(Player.LastAte);
        //Debug.Log(_timeDifference.TotalMinutes);
        TimeFadeUpdate();
        if(Player.SleepState == 0){
            handWashBubble.enabled = false;
            toiletBubble.enabled = false;
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
            //Debug.Log(_timeDifference);
            PlayStopToiletAnimation();
            PlayStopHygieneAnimation();
            PlayStopHungerAnimation();
            PlayStopHandWashAnimation();
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
     private void PlayStopToiletAnimation(){
        if(_timeDifference.TotalMinutes >= toiletTrigger && BathroomStatus.ToiletStatus == 1 && KitchenStatus.Started == false)//&& 
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("Dirty") && 
        //!animTransition.GetCurrentAnimatorStateInfo(0).IsName("Wave"))
        {
            skinsManager.Eyebrows.sprite = skinsManager.EyebrowsSpriteOptions[1];
            skinsManager.Mouth.sprite = skinsManager.MouthSpriteOptions[1];
            skinsManager.Mouth.sprite = skinsManager.MouthSpriteOptions[1];
            //animTransition.SetBool("isHungry", true);
            FadeInOutBubble(toiletBubble);   
            return;    

        }
        //animTransition.SetBool("isHungry", false);
        //hungerBubble.CrossFadeAlpha(0, 0.5f, true);
        toiletBubble.enabled = false;
    }
    private void PlayStopHygieneAnimation(){
        if((int)Player.Hygiene <= hygieneTrigger && !(_timeDifference.TotalMinutes >= toiletTrigger && BathroomStatus.ToiletStatus == 1))
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
        if((int)Player.Hunger <= hungerTrigger && !((int)Player.Hygiene <= hygieneTrigger) && !(_timeDifference.TotalMinutes >= toiletTrigger && BathroomStatus.ToiletStatus == 1)) 
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
    private void PlayStopHandWashAnimation(){
        if(KitchenStatus.HandWash == false || BathroomStatus.ToiletStatus == 2)
        {
            skinsManager.Eyebrows.sprite = skinsManager.EyebrowsSpriteOptions[1];
            skinsManager.Mouth.sprite = skinsManager.MouthSpriteOptions[1];
            skinsManager.Mouth.sprite = skinsManager.MouthSpriteOptions[1];
            FadeInOutBubble(handWashBubble);   
            return;
        }
        handWashBubble.enabled = false;    
    }
    private void PlayStopSleepyAnimation(){
        if((int)Player.Energy <= tiredTrigger && !((int)Player.Hunger <= hungerTrigger) && KitchenStatus.Started == false && !(_timeDifference.TotalMinutes >= toiletTrigger && BathroomStatus.ToiletStatus == 1))
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
            FindObjectOfType<AudioManager>().Play("Hello");
            animTransition.SetTrigger("Wave");
        }      
    }
}
