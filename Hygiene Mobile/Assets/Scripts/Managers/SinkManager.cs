using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SinkManager: MonoBehaviour
{
    public Animator transition;
    [SerializeField]
    private float _transitionTime = 1f;
    private string _levelName;
    /////
    public static float HandWashStep = 0;
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
    public void FinishClicked(){
        if(KitchenStatus.EatStatus == 1)
            KitchenStatus.EatStatus = 0;
        else if(KitchenStatus.EatStatus == 2)
            KitchenStatus.ToothbrushStatus = 1; 
        SinkManager.HandWashStep = 0;
    }
    private void OnDestroy() {
        if(SinkManager.HandWashStep == 7){
            if(KitchenStatus.EatStatus == 1)
                KitchenStatus.EatStatus = 0;
            else if(KitchenStatus.EatStatus == 2)
                KitchenStatus.ToothbrushStatus = 1;
        }
        SinkManager.HandWashStep = 0;
    }

    public void LoadNextLevel()
    {
        if(KitchenStatus.EatStatus == 2)
            _levelName = "Toothbrush";
        else if(KitchenStatus.EatStatus == 0)
            _levelName = "Kitchen";
    
        StartCoroutine(LoadLevel(_levelName));       
    }

    IEnumerator LoadLevel(string levelName){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
