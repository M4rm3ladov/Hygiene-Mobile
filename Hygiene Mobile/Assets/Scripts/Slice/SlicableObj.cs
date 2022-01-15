using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicableObj : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Cut"){
            if(gameObject.tag == "Life"){
                SliceManager.instance.IncreaseLife();
                Destroy(gameObject);
                return;
            }
            SliceManager.instance.IncreaseScore();
            SliceManager.instance.IncreaseCoin();
            Destroy(gameObject);
        }
    }
}
