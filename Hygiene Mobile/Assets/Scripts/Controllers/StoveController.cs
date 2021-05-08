using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveController : MonoBehaviour
{
    [SerializeField]
    private GameObject Table;
    [SerializeField]
    private float _transitionTime = 1f;
    private int _clicked = 0;
    private void OnMouseDown() {
        StoveClicked();           
    }
    private void StoveClicked(){
        if(_clicked == 0){
            _clicked = 1;
            Table.SetActive(true);
            return;
        }
        _clicked = 0;
        Table.SetActive(false);
        return;  
    }
}
