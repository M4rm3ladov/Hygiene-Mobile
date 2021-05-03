using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public int tiredTrigger;
    [SerializeField]
    private int hungerTrigger;
    [Header("Mouth Sprite")]
    public SpriteRenderer Mouth;
    [Header("Cycle Through")]
    public List<Sprite> MouthSpriteOptions = new List<Sprite>();

    [Header("Eyes Sprite")]
    public SpriteRenderer Eyes;
    [Header("Cycle Through")]
    public List<Sprite> EyesSpriteOptions = new List<Sprite>();
    [Header("Eyebrows Sprite")]
    public SpriteRenderer Eyebrows;
    [Header("Cycle Through")]
    public List<Sprite> EyebrowsSpriteOptions = new List<Sprite>();
    //[Header("Mouth Sprite")]
    
    private void Start() {
        if((int)Player.Energy <= tiredTrigger)
        {
            //Debug.Log("sleepy");
            SleepyStateTransition();         
        }
        else if((int)Player.Energy > tiredTrigger)
        {
            //Debug.Log("rested");
            NormalStateTransition();
        }  
    }
    private void Update() {
        if((int)Player.Energy == tiredTrigger)
        {
            //Debug.Log("sleepy");
            SleepyStateTransition();         
        }
        /*else if((int)Player.Energy == tiredTrigger + 1)
        {
            Debug.Log("Wrong");
            NormalStateTransition();
        } */ 
    }
    public void SleepyStateTransition(){
        Eyes.sprite = EyesSpriteOptions[3];
        Eyebrows.sprite = EyebrowsSpriteOptions[1];
        Mouth.sprite = MouthSpriteOptions[1];
    }
    public void NormalStateTransition(){
        Eyes.sprite = EyesSpriteOptions[0];
        Eyebrows.sprite = EyebrowsSpriteOptions[0];
        Mouth.sprite = MouthSpriteOptions[0];
    }
}
