using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveController : MonoBehaviour
{
    [SerializeField]
    private GameObject ItemCount;
    [SerializeField]
    private GameObject Table;
    [SerializeField]
    private GameObject Left;
    [SerializeField]
    private GameObject Right;
    private int _clicked = 0;
    private void OnMouseDown() {
        StoveClicked();           
    }
    private void StoveClicked(){
        if(_clicked == 0){
            _clicked = 1;
            ItemCount.SetActive(true);
            Table.SetActive(true);
            Left.SetActive(true);
            Right.SetActive(true);
            return;
        }
        _clicked = 0;
        ItemCount.SetActive(false);
        Table.SetActive(false);
        Left.SetActive(false);
        Right.SetActive(false);
        return;  
    }
}
