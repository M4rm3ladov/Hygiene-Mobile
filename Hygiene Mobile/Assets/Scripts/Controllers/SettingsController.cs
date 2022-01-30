using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    private GameObject pnlSettings;
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private Toggle soundToggle;
    [SerializeField]
    private GameObject img;
    private GameObject[] gObject;

    public void ChangeVolume(){
        FindObjectOfType<AudioManager>().AdjustVolume("Theme", volumeSlider.value);
    }
    public void ToggleSound(){
        FindObjectOfType<AudioManager>().ToggleSoundEffects(soundToggle.isOn);
    }
    public void ShowSettings(){
        gObject = GameObject.FindGameObjectsWithTag("Interactable");
 
        foreach (GameObject j in gObject){
            if(j.name == "toilet" || j.name == "bathtub" || j.name == "sinkBath" || j.name == "Faucet"){
                j.GetComponent<PolygonCollider2D>().enabled = false;
                continue;
            }
            j.GetComponent<BoxCollider2D>().enabled = false;
        }
     
        pnlSettings.SetActive(true);
        img.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseSettings(){
        gObject = GameObject.FindGameObjectsWithTag("Interactable");
        
        foreach (GameObject j in gObject){
            if(j.name == "toilet" || j.name == "bathtub" || j.name == "sinkBath" || j.name == "Faucet"){
                j.GetComponent<PolygonCollider2D>().enabled = true;
                continue;
            }
            j.GetComponent<BoxCollider2D>().enabled = true;
        }
        pnlSettings.SetActive(false);
        img.SetActive(false);
        Time.timeScale = 1;
    }
    public void Logout(){
        Application.Quit();
    }
}
