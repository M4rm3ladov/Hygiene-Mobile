using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    // Update is called once per frame
    private void OnMouseDown() {
        LoadNextLevel();
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel(){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        
    }
}
