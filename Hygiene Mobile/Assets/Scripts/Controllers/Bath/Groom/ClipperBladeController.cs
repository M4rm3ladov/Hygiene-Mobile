using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipperBladeController : MonoBehaviour
{
    [SerializeField]
    Animator clipperA;
    NailsManager nailsManager;
    private List<GameObject> nails = new List<GameObject>();   
    private string nName;
    private int index;
    private float addend = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        nailsManager = GetComponent<NailsManager>();
        clipperA.enabled = false;
        
    }                       
    private void OnTriggerExit2D(Collider2D other) {
        if(other.name != nName){
            clipperA.enabled = false;
            FindObjectOfType<AudioManager>().Stop("Nail");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        for (int i = 0; i < nailsManager.Nails.Count; i++)
        {   
            index = i;
            if(nailsManager.Nails[i].name == other.name){
                FindObjectOfType<AudioManager>().Play("Nail");
                nName = nailsManager.Nails[i].name;
                break;
            }
        }
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){
            if(nName == other.name){
                //nName = "";
                clipperA.enabled = true;
                nailsManager.Nails[index].SetActive(false); 
                nailsManager.Nails.RemoveAt(index);
                if(nailsManager.Nails.Count == 0){
                    BathroomManager.BathStep = 8; 
                    return;
                }
                BathroomManager.BathStep += addend;
            }        
        }
    }
}
