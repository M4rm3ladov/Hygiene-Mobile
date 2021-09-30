using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BathroomManager: MonoBehaviour
{
    public Animator transition;
    [SerializeField]
    private float _transitionTime = 1f;
    [SerializeField]
    public static float BathStep = 0;
    [SerializeField]
    private Image currentProgress;
    [SerializeField]
    private Text textProgress;
    [SerializeField]
    private GameObject progressBar;
    [SerializeField]
    private GameObject finishButton;
    SkinsManager skinsManager;

    private float _max = 10;
    
    public Image CurrentProgress{
        get{ return currentProgress; }
        set{ currentProgress = value; }
    }
    public Text TextProgress{
        get{ return textProgress; }
        set{ textProgress = value; }
    }

    private void Start() {
        skinsManager = GameObject.Find("Body").GetComponent<SkinsManager>();

        if(Player.EquippedSkins[0] == 3)
            skinsManager.Hair.sprite = skinsManager.HairSpriteOptions[0];
        UpdateProgressBar();
    }
    private void Update() {
        if(BathStep > 10)
            return;
        if(BathStep == 10){
            Player.Hygiene += 100;
            BathStep += .01f;
            finishButton.SetActive(true); 
        }
        UpdateProgressBar();
    }
    public void UpdateProgressBar()
    {
        float ratio = BathStep / _max;
        currentProgress.rectTransform.localScale = new Vector3(ratio, 1, 1);
        textProgress.text = (ratio * 100).ToString("0") + "%";
    }
    public void FinishClicked(){
        BathStep = 0;
        StartCoroutine(LoadLevel("Closet"));
    }

     IEnumerator LoadLevel(string levelName){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelName);
    }

    private void OnDestroy() {
        BathStep = 0;
    }
}
