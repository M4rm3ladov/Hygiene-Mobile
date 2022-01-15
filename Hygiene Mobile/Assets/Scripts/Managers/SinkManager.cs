using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SinkManager: MonoBehaviour
{
    Player player;
    public Animator transition;
    [SerializeField]
    private float _transitionTime = 1f;
    private string _levelName;
    /////
    public static float HandWashStep = 7;
    [SerializeField]
    private Image currentProgress;
    [SerializeField]
    private Text textProgress;
    [SerializeField]
    private GameObject progressBar;
    [SerializeField]
    private GameObject finishButton;
    [SerializeField]
    private List<Sprite> imgBack = new List<Sprite>();
    [SerializeField]
    private Image back;
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
        HandWashStep = 0;
        player = GetComponent<Player>();
        if(BathroomStatus.ToiletStatus == 2)
            back.sprite = imgBack[1];
        else
            back.sprite =imgBack[0];
        UpdateProgressBar();
    }
    private void Update() {
        if(HandWashStep > 7)
            return;
        if(HandWashStep == 7){
            Player.Hygiene += 5;
            if(Player.Hygiene >= 100)
                Player.Hygiene = 100;
            HandWashStep += .01f;
            finishButton.SetActive(true);
        }
        UpdateProgressBar();
    }
    public void UpdateProgressBar()
    {
        float ratio = HandWashStep / _max;
        currentProgress.rectTransform.localScale = new Vector3(ratio, 1, 1);
        textProgress.text = (ratio * 100).ToString("0") + "%";
    }
    public void FinishClicked(){
        if(BathroomStatus.ToiletStatus != 2){
            if(KitchenStatus.EatStatus == 1){
                KitchenStatus.EatStatus = 0;
                KitchenStatus.HandWash = true;
            }
            else if(KitchenStatus.EatStatus == 2){
                KitchenStatus.ToothbrushStatus = 1;
            }
            player.SavePlayer(); 
        }
   
        if(KitchenStatus.EatStatus == 2)
            _levelName = "Toothbrush";
        else if(KitchenStatus.EatStatus == 0)
            _levelName = "Kitchen";

        if(BathroomStatus.ToiletStatus == 2){
            _levelName = "Bathroom";
            if(HandWashStep >= 7)
                BathroomStatus.ToiletStatus = 0;
            player.SavePlayer();
        }
        HandWashStep = 0;
        StartCoroutine(LoadLevel(_levelName));    
    }
    /*private void OnDestroy() {
        SinkManager.HandWashStep = 0;
        if(Player.ToiletStatus == 3){
            Player.ToiletStatus = 0;
            return;
        }else if(Player.ToiletStatus == 2)
            return;
        
    }*/

    public void BackClick()
    {
        _levelName = "Kitchen";

        if(BathroomStatus.ToiletStatus != 2 && HandWashStep >= 7){
            if(KitchenStatus.EatStatus == 1){
                KitchenStatus.EatStatus = 0;
            }
            else if(KitchenStatus.EatStatus == 2){
                KitchenStatus.ToothbrushStatus = 1;
            }
            player.SavePlayer(); 
        }

        if(BathroomStatus.ToiletStatus == 2){
            _levelName = "Bathroom";
            if(HandWashStep >= 7)
                BathroomStatus.ToiletStatus = 0;
            player.SavePlayer();
        }
        SinkManager.HandWashStep = 0;
        StartCoroutine(LoadLevel(_levelName));       
    }

    IEnumerator LoadLevel(string levelName){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
