using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToiletManager : MonoBehaviour
{
    Player player;
    SpriteRenderer eyeSprite ;
    SpriteRenderer mouthSprite; 
    [SerializeField]
    private List<Sprite> eye = new List<Sprite>();
    [SerializeField]
    private List<Sprite> mouth = new List<Sprite>();
    [SerializeField]
    public static float ToiletStep = 3;
    [SerializeField]
    private Image currentProgress;
    [SerializeField]
    private Text textProgress;
    [SerializeField]
    private GameObject progressBar;
    [SerializeField]
    private GameObject finishButton;
    private float _max = 3;
    private float timeStep = 4;
    private bool finTrig = false;
    
    public Image CurrentProgress{
        get{ return currentProgress; }
        set{ currentProgress = value; }
    }
    public Text TextProgress{
        get{ return textProgress; }
        set{ textProgress = value; }
    }

    private void Start() {
        ToiletStep = 0;
        if(PlayerPrefs.GetInt("gender") == 0)
            player = GameObject.Find("Player").GetComponent<Player>();
        else if(PlayerPrefs.GetInt("gender") == 1)
            player = GameObject.Find("Girl").GetComponent<Player>();
        eyeSprite = GameObject.Find("Eyes").GetComponent<SpriteRenderer>();
        mouthSprite = GameObject.Find("Mouth").GetComponent<SpriteRenderer>();
        UpdateProgressBar();
    }
    private void LateUpdate() {
        if(finTrig)
            return;

        if(timeStep >= 0){      
            timeStep -= Time.deltaTime;
            if((int)timeStep % 2 == 0){
                eyeSprite.sprite = eye[1];
                mouthSprite.sprite = mouth[1];
            }
            else{
                mouthSprite.sprite = mouth[0];
                eyeSprite.sprite = eye[0];
            }
        }

        if(timeStep < 0){
            ToiletStep = 1;
            finTrig = true;
        }
    }
    private void Update() {
        if(ToiletStep > 3 )
            return;
        if(ToiletStep == 3){
            BathroomStatus.ToiletStatus = 2;
            Player.Hygiene += 5;
            if(Player.Hygiene >= 100)
                Player.Hygiene = 100;
            ToiletStep += .01f;
            finishButton.SetActive(true); 
            player.SavePlayer();
        }
        UpdateProgressBar();
    }
    public void UpdateProgressBar()
    {
        float ratio = ToiletStep / _max;
        currentProgress.rectTransform.localScale = new Vector3(ratio, 1, 1);
        textProgress.text = (ratio * 100).ToString("0") + "%";
    }
    public void FinishClicked(){
        ToiletStep = 0;
    }

    private void OnDestroy() {
        ToiletStep = 0;
    }
}
