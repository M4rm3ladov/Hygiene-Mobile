using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public Animator transition;
    [SerializeField]
    private float _transitionTime = 1f;
    [SerializeField]
    private string _levelName;
    // Update is called once per frame
    private void OnMouseDown() {
        LoadNextLevel();
    }
    public void LoadNextLevel()
    {
        //wakes up character when switching scene
        Player.SleepState = 1;  
        if(KitchenStatus.EatStatus != 2){
            KitchenStatus.EatStatus = 0;
        }else{
            return;
        }
        StartCoroutine(LoadLevel(_levelName));       
    }

    IEnumerator LoadLevel(string levelName){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
