using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushingManager : MonoBehaviour
{
    Player player;
    public static float ToothbrushStep = 5;
    [SerializeField]
    private Image currentProgress;
    [SerializeField]
    private Text textProgress;
    [SerializeField]
    private GameObject progressBar;
    [SerializeField]
    private GameObject finishButton;
    private float _max = 5;
    public Image CurrentProgress{
        get{ return currentProgress; }
        set{ currentProgress = value; }
    }
    public Text TextProgress{
        get{ return textProgress; }
        set{ textProgress = value; }
    }
    private void Start() {
        ToothbrushStep = 0;
        player = GetComponent<Player>();
        UpdateProgressBar();
    }
    private void Update() {
        if(ToothbrushStep > 5)
            return;
        if(ToothbrushStep == 5){
            Player.Hygiene += 5;
            if(Player.Hygiene >= 100)
                Player.Hygiene = 100;
            ToothbrushStep += .01f;
            finishButton.SetActive(true);
            player.SavePlayer();
        }
        UpdateProgressBar();
    }
    public void UpdateProgressBar()
    {
        float ratio = ToothbrushStep / _max;
        currentProgress.rectTransform.localScale = new Vector3(ratio, 1, 1);
        textProgress.text = (ratio * 100).ToString("0") + "%";
    }
    public void FinishedClicked(){
        KitchenStatus.EatStatus = 0;
        KitchenStatus.ToothbrushStatus = 0;
        KitchenStatus.Started = false;
        KitchenStatus.HandWash = true;
        BrushingManager.ToothbrushStep = 0;
    }
    private void OnDestroy() {
        if(BrushingManager.ToothbrushStep >= 5){
            KitchenStatus.EatStatus = 0;
            KitchenStatus.ToothbrushStatus = 0;
            KitchenStatus.Started = false;
            KitchenStatus.HandWash = true;
        }
        BrushingManager.ToothbrushStep = 0;
    }
}
