using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushingManager : MonoBehaviour
{
    public static float ToothbrushStep = 0;
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
        UpdateProgressBar();
    }
    private void Update() {
        if(ToothbrushStep == 5)
            finishButton.SetActive(true);
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
        BrushingManager.ToothbrushStep = 0;
    }
    private void OnDestroy() {
        if(BrushingManager.ToothbrushStep == 5){
            KitchenStatus.EatStatus = 0;
            KitchenStatus.ToothbrushStatus = 0;
            KitchenStatus.Started = false;
        }
        BrushingManager.ToothbrushStep = 0;
    }
}
