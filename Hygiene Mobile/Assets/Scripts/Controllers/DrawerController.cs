using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{   
    [SerializeField]
    private float _transitionTime = 1f;
    private void OnMouseDown() {
        Debug.Log("Tap");
        StartCoroutine(FadeOjbect());      
    }
    IEnumerator FadeOjbect(){
        yield return new WaitForSeconds(_transitionTime);    
    }
}
