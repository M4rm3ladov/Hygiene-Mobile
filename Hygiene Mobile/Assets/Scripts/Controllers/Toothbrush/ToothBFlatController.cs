using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBFlatController : MonoBehaviour
{
    [SerializeField]
    ToothbrushManager toothbrushManager;
    private void OnTriggerStay2D(Collider2D other) {
        if(other.name == "top" || other.name == "bottom"){
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[2];
            SinkManager.ToothbrushStep = 2;
        }
        if(other.name == "topL" || other.name == "bottomL"){
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[4];
            SinkManager.ToothbrushStep = 2;
        }
        if(other.name == "topR" || other.name == "bottomR"){
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[3];
            SinkManager.ToothbrushStep = 2;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(SinkManager.ToothbrushStep == 1)
            return;
        toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[0];
    }
}
