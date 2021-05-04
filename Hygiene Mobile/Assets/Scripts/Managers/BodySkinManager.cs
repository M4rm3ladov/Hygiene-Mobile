using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySkinManager : MonoBehaviour
{
    [Header("Torso")]
    public SpriteRenderer Torso;
    [Header("Cycle Through")]
    public List<Sprite> TorsoSpriteOptions = new List<Sprite>();
    [Header("Left Arm")]
    public SpriteRenderer LeftArm;
    [Header("Cycle Through")]
    public List<Sprite> LeftArmSpriteOptions = new List<Sprite>();
    [Header("Right Arm")]
    public SpriteRenderer RightArm;
    [Header("Cycle Through")]
    public List<Sprite> RightArmSpriteOptions = new List<Sprite>();
    [Header("Left Leg")]
    public SpriteRenderer LeftLeg;
    [Header("Cycle Through")]
    public List<Sprite> LeftLegSpriteOptions = new List<Sprite>();
    [Header("Right Leg")]
    public SpriteRenderer RightLeg;
    [Header("Cycle Through")]
    public List<Sprite> RightLegSpriteOptions = new List<Sprite>();
    private int _currentOption = 0;
    public void NextOption()
    {
        
    }
    public void PreviousOption()
    {
        
    }

}
