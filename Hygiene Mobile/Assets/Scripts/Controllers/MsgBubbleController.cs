using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MsgBubbleController : MonoBehaviour
{
    private Scene currentScene;
    [SerializeField]
    private Image dirtyBubble;
    [SerializeField]
    private Image hungerBubble;
    [SerializeField]
    private Image tiredBubble;

    public Animator transition;
    [SerializeField]
    private float _transitionTime = 1f;
    [SerializeField]
    private string _levelName;
    private void Start() {
        currentScene = SceneManager.GetActiveScene();
    }
    public void ClickEvent() {
        if(KitchenStatus.EatStatus != 2){
            KitchenStatus.EatStatus = 0;
        }else{
            return;
        }
        
        if(hungerBubble.enabled == true){
            if(currentScene.name == "Kitchen")
                return;
            StartCoroutine(LoadLevel(_levelName));    
        }
        if(tiredBubble.enabled == true){
            if(currentScene.name == "Bedroom")
                return;
            StartCoroutine(LoadLevel(_levelName));    
        }
    }
    IEnumerator LoadLevel(string levelName){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
