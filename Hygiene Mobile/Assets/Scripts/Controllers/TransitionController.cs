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
    PlayerController playerController;
    private void Start() {
        if(PlayerPrefs.GetInt("gender") == 0)
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        else if(PlayerPrefs.GetInt("gender") == 1)
            playerController = GameObject.Find("Girl").GetComponent<PlayerController>();
        
        Debug.Log(BathroomStatus.ToiletStatus & playerController.HygieneTrigger & playerController.HungerTrigger & playerController.TiredTrigger);
    }
    private void OnMouseDown() {
        LoadNextLevel();
    }
    public void LoadNextLevel()
    {
        if(_levelName != "Kitchen" && KitchenStatus.Started == false){
            KitchenStatus.HandWash = true;
        }
        
        if(currentScene.name == "Kitchen"  && _levelName != "Store" && KitchenStatus.Started == true){
            KitchenStatus.HandWash = false;
            Debug.Log("second");
        }

        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Bedroom" || currentScene.name == "Bathroom" || currentScene.name == "Games")
            KitchenStatus.EatStatus = 1;

        if(currentScene.name == "Kitchen" && _levelName == "Sink"){
            if(KitchenStatus.ToothbrushStatus == 1)
                _levelName = "Toothbrush";
            if(KitchenStatus.EatStatus == 0)
                return;
        }

        if(currentScene.name == "Kitchen"){
            if(_levelName == "Bedroom" ||  _levelName == "Bathroom" || _levelName == "Games"){
                if(KitchenStatus.EatStatus != 0 && KitchenStatus.Started == true)
                    return;
            }
        }

        if(currentScene.name == "Bathroom" && _levelName != "Sink" && BathroomStatus.ToiletStatus == 2)
            return;
        if(currentScene.name == "Bathroom" && _levelName == "Sink" && BathroomStatus.ToiletStatus <= 1)
            return;
        if(currentScene.name == "Bathroom" && _levelName == "CR" && BathroomStatus.ToiletStatus != 1)
            return;
        if(currentScene.name == "Bathroom" && _levelName == "Bathtub" && Player.Hygiene > 10)
            return;

        //wakes up character when switching scene
        Player.SleepState = 1;  
        if(_levelName == "Closet" || _levelName == "Store" || _levelName == "CR")
            FindObjectOfType<AudioManager>().Play("Cabinet");
        else if(_levelName == "Sink" || _levelName == "Bathtub")
            FindObjectOfType<AudioManager>().Play("Squeak");

        if(_levelName == "Games"){
            if(BathroomStatus.ToiletStatus >= 1 || ((int)Player.Hunger <= playerController.HungerTrigger || (int)Player.Hygiene <= playerController.HygieneTrigger || (int)Player.Energy <= playerController.TiredTrigger))
                return;
        }
        StartCoroutine(LoadLevel(_levelName));       
    }

    IEnumerator LoadLevel(string levelName){
        transition.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(_transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
