using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsManager : MonoBehaviour
{
    [Header("Eyebrows")]
    public SpriteRenderer Eyebrows;
    [Header("Cycle Through")]
    public List<Sprite> EyebrowsSpriteOptions = new List<Sprite>();  
    [Header("Eyes")]
    public SpriteRenderer Eyes;
    [Header("Cycle Through")]
    public List<Sprite> EyesSpriteOptions = new List<Sprite>();  
    [Header("Mouth")]
    public SpriteRenderer Mouth;
    [Header("Cycle Through")]
    public List<Sprite> MouthSpriteOptions = new List<Sprite>();  
    [Header("Hair")]
    public SpriteRenderer Hair;
    [Header("Cycle Through")]
    public List<Sprite> HairSpriteOptions = new List<Sprite>();
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
    private void Start() { 
        Hair.sprite = HairSpriteOptions[Player.EquippedSkins[0]];
        Torso.sprite = TorsoSpriteOptions[Player.EquippedSkins[1]];
        LeftArm.sprite = LeftArmSpriteOptions[Player.EquippedSkins[1]];
        RightArm.sprite = RightArmSpriteOptions[Player.EquippedSkins[1]];
        LeftLeg.sprite = LeftLegSpriteOptions[Player.EquippedSkins[1]];
        RightLeg.sprite = RightLegSpriteOptions[Player.EquippedSkins[1]];    
    }
}
