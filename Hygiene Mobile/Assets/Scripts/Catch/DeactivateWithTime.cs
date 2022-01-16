using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateWithTime : MonoBehaviour
{
    [SerializeField]
    private float time = 1.1f;
    private float currentTime;
    Scene currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        currentTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0){
            currentTime = time;
            if(currentScene.name == "Slice"){
                Destroy(gameObject);                
                return;
            }
            gameObject.SetActive(false);
        }
    }
}
