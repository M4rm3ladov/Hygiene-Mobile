using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaucetController : MonoBehaviour
{
    [SerializeField]
    Button bedButton;
    [SerializeField]
    Button kitchenButton;
    [SerializeField]
    Button gameButton;
    [SerializeField]
    Button bathButton;
    [SerializeField]
    HandWashManager handWashManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnMouseDown() {
        if(KitchenStatus.EatStatus == 0){
            KitchenStatus.EatStatus = 1;
            handWashManager.HandWashBubble.SetActive(false);
        }else if(KitchenStatus.EatStatus == 2){
            handWashManager.HandWashBubble.SetActive(false);
            handWashManager.BrushBubble.SetActive(false);
            KitchenStatus.EatStatus = 1;
        }
    }
}
