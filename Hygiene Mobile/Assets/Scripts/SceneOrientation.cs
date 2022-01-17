using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneOrientation : MonoBehaviour
{
    Scene currentScene;
    private void Start() {
        currentScene = SceneManager.GetActiveScene();
        StartCoroutine(CheckOrientation(currentScene));     
    }
    private void OnApplicationPause(bool pauseStatus) {
        currentScene = SceneManager.GetActiveScene();
        if(!pauseStatus)
            StartCoroutine(CheckOrientation(currentScene));
    }
    IEnumerator CheckOrientation(Scene currentScene){
        if(currentScene.name == "Catch" || currentScene.name == "Quiz"){
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.orientation = ScreenOrientation.Portrait;
            while(Screen.orientation != ScreenOrientation.Portrait)
                yield return null;    
        }else{ 
            Screen.autorotateToPortrait = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToLandscapeLeft = true;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            while(Screen.orientation != ScreenOrientation.LandscapeLeft)
                yield return null;   
        }  
    }
}
