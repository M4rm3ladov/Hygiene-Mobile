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
    private Scene currentScene;
    private void OnMouseDown() {
        LoadNextLevel();
    }
    public void LoadNextLevel()
    {
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Bedroom" || currentScene.name == "Livingroom")
            KitchenStatus.EatStatus = 1;

        if(currentScene.name == "Kitchen" && _levelName == "Sink"){
            if(KitchenStatus.ToothbrushStatus == 1)
                _levelName = "Toothbrush";
            if(KitchenStatus.EatStatus == 0)
                return;
        }

        if(currentScene.name == "Kitchen"){
            if(_levelName == "Bedroom" || _levelName == "Livingroom" || _levelName == "Bathroom"){
                if(KitchenStatus.EatStatus != 0 && KitchenStatus.Started == true)
                    return;
            }
        }
        //wakes up character when switching scene
        Player.SleepState = 1;  
        StartCoroutine(LoadLevel(_levelName));       
    }

    IEnumerator LoadLevel(string levelName){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
