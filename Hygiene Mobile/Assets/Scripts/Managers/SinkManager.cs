using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinkManager: MonoBehaviour
{
    public static float HandWashStep = 0;
    public static int ToothbrushStep = 0;
    [SerializeField]
    private Image currentProgress;
    [SerializeField]
    private Text textProgress;
    [SerializeField]
    private GameObject progressBar;
    [SerializeField]
    private GameObject finishButton;

    private float _max = 7;
    
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
        //if(HandWashStep > 0)
         //   progressBar.SetActive(true);
        if(HandWashStep == 7)
            finishButton.SetActive(true);
        UpdateProgressBar();
    }
    public void UpdateProgressBar()
    {
        float ratio = HandWashStep / _max;
        currentProgress.rectTransform.localScale = new Vector3(ratio, 1, 1);
        textProgress.text = (ratio * 100).ToString("0") + "%";
    }
}
