using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    [SerializeField]
    private GameObject RoomLight;
    [SerializeField]
    private GameObject Body;
    [SerializeField]
    private GameObject SleepHead;
    private int _lightState = 0;
    
    private void OnMouseDown() {
        if(_lightState == 0)
        {
            RoomLight.SetActive(true);
            Body.SetActive(false);
            _lightState = 1; 

            SpriteRenderer[] sprites = SleepHead.GetComponentsInChildren<SpriteRenderer>();
 
            for(int i = 0; i < sprites.Length; i++){
            sprites[i].enabled = true;
            }
        }
        else if(_lightState == 1)
        {
            RoomLight.SetActive(false);
            Body.SetActive(true);
            _lightState = 0;

            SpriteRenderer[] sprites = SleepHead.GetComponentsInChildren<SpriteRenderer>();
 
            for(int i = 0; i < sprites.Length; i++){
            sprites[i].enabled = false;
            }
        }               
    }
}
