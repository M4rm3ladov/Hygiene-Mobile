using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothPSqueezeController : MonoBehaviour
{
    [SerializeField]
    ToothbrushManager toothbrushManager;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "bristle"){
            toothbrushManager.Toothbrush.sprite = toothbrushManager.ToothBSpriteOptions[1];
            SinkManager.ToothbrushStep = 1;
        }
    }
}
