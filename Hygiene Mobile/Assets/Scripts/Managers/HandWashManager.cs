using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWashManager : MonoBehaviour
{
    [SerializeField]
    GameObject handWashBubble;
    [SerializeField]
    GameObject brushBubble;
    public GameObject HandWashBubble{
        get{ return handWashBubble;}
        set{ handWashBubble = value;}
    }
    public GameObject BrushBubble{
        get{ return brushBubble;}
        set{ brushBubble = value;}
    }
    // Start is called before the first frame update
    void Start()
    {
        if(KitchenStatus.EatStatus == 0)
            ShowHandWashBubble();
        
        if(KitchenStatus.EatStatus == 2){
            ShowBrushBubble();
            ShowHandWashBubble();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowHandWashBubble(){
        handWashBubble.SetActive(true);
    }
    public void ShowBrushBubble(){
        brushBubble.SetActive(true);
    }

}
