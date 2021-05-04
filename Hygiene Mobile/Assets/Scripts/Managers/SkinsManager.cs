using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsManager : MonoBehaviour
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

    [Header("Hair")]
    public SpriteRenderer Hair;
    [Header("Cycle Through")]
    public List<Sprite> HairSpriteOptions = new List<Sprite>();
}
