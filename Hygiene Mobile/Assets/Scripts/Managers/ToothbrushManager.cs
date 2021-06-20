using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothbrushManager : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer toothbrush;
    [SerializeField]
    private List<Sprite> toothBSpriteOptions = new List<Sprite>(); 
    public SpriteRenderer Toothbrush{
        get{ return toothbrush; }
        set{ toothbrush = value; }
    }
    public List<Sprite> ToothBSpriteOptions{
        get{ return toothBSpriteOptions;}
        set{ toothBSpriteOptions = value;}
    }
}
