using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    Player player;
    [SerializeField]
    AdsManager adsManager;
    public static int gameIsPaused = 0;
    [SerializeField]
    private Text scoreText, coinText, pausehighScore, pauseScore, gameOverScore, gamehighScore, coinEarned;
    [SerializeField]
    private Image[] Life; 
    [SerializeField]
    private GameObject panelAlpha, continueMenu, gameOverMenu, pauseMenu;
    private int coinRandomCounter = 1;
    private bool extraLifeReward = true;
    private int currentScore, currentCoin, currentLife;
    // Start is called before the first frame update
    private void Awake() {
        if(instance == null)
            instance = this;
    }
    void Start()
    {
        if(PlayerPrefs.GetInt("gender") == 0)
            player = GameObject.Find("Boy").GetComponent<Player>();
        else if(PlayerPrefs.GetInt("gender") == 1)
            player = GameObject.Find("Girl").GetComponent<Player>();

        currentLife = 3;
        scoreText.text = "" + 0;
        coinText.text = "" + 0;
        pausehighScore.text = "" + Player.HighScore[0];
        gamehighScore.text = "" + Player.HighScore[0]; 
    }
    public void IncreaseCoin(){
        if(currentScore % 10 > 0 && currentScore % 10 < 5 && currentScore >= 10){   
            if(coinRandomCounter == 0)
                return;
            int r = Random.Range(0, 5);
            if(r == 1){
                coinRandomCounter = 0;
                currentCoin++;
                coinText.text = "" + currentCoin;
                ConsumeSpawner.instance.Speed += .025f;
                ConsumeSpawner.instance.DelayTime -= .25f;
                PlayerAnimationController.instance.moveSpeed += .01f;
                Player.GoldCoins ++;
                player.SavePlayer();
            }else
                coinRandomCounter++;
        }else if(currentScore % 10 == 5 && coinRandomCounter > 0 && currentScore >= 10){
            currentCoin++;
            coinText.text = "" + currentCoin;
            ConsumeSpawner.instance.Speed += .025f;
            ConsumeSpawner.instance.DelayTime -= .25f;
            PlayerAnimationController.instance.moveSpeed += .01f;
            Player.GoldCoins ++;
            player.SavePlayer();
        }else if(currentScore % 10 >= 6)
            coinRandomCounter = 1;

        if(ConsumeSpawner.instance.DelayTime < 2)
            ConsumeSpawner.instance.DelayTime = 1;
        if(ConsumeSpawner.instance.Speed > 5)
            ConsumeSpawner.instance.Speed = 5;
    }
    public void IncreaseScore(){
        currentScore++;
        scoreText.text = "" + currentScore;
        if(currentScore > Player.HighScore[0]){
            Player.HighScore[0] = currentScore;
            player.SavePlayer();
        } 
    }
    public void DecreaseLife(){
        currentLife--;
        if(currentLife < 0)
            currentLife = 0;
        switch (currentLife)
        {
            case 2:
                Life[2].CrossFadeAlpha(0.5f, 0, true);
                break;
            case 1:
                Life[1].CrossFadeAlpha(0.5f, 0, true);
                break;
            case 0:
                Life[0].CrossFadeAlpha(0.5f, 0, true);
                break;
        }
        if(currentLife == 0 && !extraLifeReward)
            GameOver();
        else if(currentLife == 0 && extraLifeReward){
            ContinueWithAd();
            extraLifeReward = false;
        }
    }
    public void IncreaseLife(){
        currentLife++;
        if(currentLife > 3)
            currentLife = 3;
        switch (currentLife)
        {
            case 3:
                Life[2].CrossFadeAlpha(1, 0, true);
                break;
            case 2:
                Life[1].CrossFadeAlpha(1, 0, true);
                break;
            case 1:
                Life[0].CrossFadeAlpha(1, 0, true);
                break;
        }
    }
    public void RestartGame(){
        Time.timeScale = 1f;
        gameIsPaused = 0;
        SceneManager.LoadScene("Catch");
    }
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        panelAlpha.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = 1;
    }
    public void PauseGame(){
        if(currentScore > Player.HighScore[0]){
            pausehighScore.text = "" + currentScore;
        }else
            pausehighScore.text = "" + Player.HighScore[0];
        pauseScore.text = "" + currentScore;
        pauseMenu.SetActive(true);
        panelAlpha.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = -1;
    }
    public void GameOver(){
        FindObjectOfType<AudioManager>().Play("Applause");  
        continueMenu.SetActive(false);
        coinEarned.text = "" + currentCoin;
        gameOverScore.text = "" + currentScore;
        gameOverMenu.SetActive(true);
        panelAlpha.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = -1;
    }
    public void ContinueWithAd(){
        if(currentScore > Player.HighScore[0]){
            gamehighScore.text = "" + currentScore;
        }else
            gamehighScore.text = "" + Player.HighScore[0];
        continueMenu.SetActive(true);
        panelAlpha.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = -1;
    }
    public void ExtraLifeClicked(){
        adsManager.ButtonType = "CatchExtra";
    }
    public void DoubleCoinsClicked(){
        adsManager.ButtonType = "CatchDouble";
    }

    public void DoubleCoins(){
        FindObjectOfType<AudioManager>().Play("Coin");
        GameObject.Find("Button_Ad").GetComponent<Button>().interactable = false;
        Player.GoldCoins -= currentCoin;
        currentCoin = currentCoin * 2;
        Player.GoldCoins += currentCoin;
        player.SavePlayer();
        coinEarned.text = "" + currentCoin;
        Time.timeScale = 0f;
    }   
    public void ContinueWithOneLife(){
        IncreaseLife();
        continueMenu.SetActive(false);
        panelAlpha.SetActive(false);   
        gameIsPaused = 1;
    }
    private void OnDestroy() {
        if(currentScore > Player.HighScore[0]){
            Player.HighScore[0] = currentScore;
            //Player.GoldCoins += currentCoin;
            player.SavePlayer();
        }
        Time.timeScale = 1f;
        gameIsPaused = 0;
    }  
    private void OnApplicationPause(bool pauseStatus) {
       if(pauseStatus && !continueMenu.activeSelf && !gameOverMenu.activeSelf)
            PauseGame();
    }
}
