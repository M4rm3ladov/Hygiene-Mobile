using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{   
    [SerializeField]
    private GameObject gameObject;
    private int _objState = 1;
    [SerializeField]
    private float _transitionTime = 1f;
    private void OnMouseDown() {
        Debug.Log("Tap");
        StartCoroutine(FadeOjbect());      
    }
    IEnumerator FadeOjbect(){
        yield return new WaitForSeconds(_transitionTime); 
        _objState = 0;     
    }
}
