using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;
    [SerializeField]
    private QuizUI quizUI;
    [SerializeField]
    private QuizScriptable quizScriptable;
    private GameStatus gameStatus = GameStatus.NEXT;
    public GameStatus GameStatus { get { return gameStatus; } }
    private List<Question> questions;
    private Question selectedQuestion;
    //
    [SerializeField]
    Player player;
    [SerializeField]
    AdsManager adsManager;
    public static int gameIsPaused = 0;
    [SerializeField]
    private Text scoreText, coinText, pausehighScore, pauseScore, gameOverScore, gamehighScore, coinEarned, timerText;
    [SerializeField]
    private Image[] Life; 
    [SerializeField]
    private GameObject panelAlpha, gameOverMenu, pauseMenu;
    [SerializeField]
    private Button btnPause;
    [SerializeField]
    private CanvasGroup transPanel;
    private int currentScore, currentCoin, currentLife;
    private float currentTime = 30;
    // Start is called before the first frame update
    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    void Start()
    {
        questions = new List<Question>();
        questions.AddRange(quizScriptable.questions);
        
        SelectQuestion();
        gameStatus = GameStatus.PLAYING;

        currentLife = 3;
        scoreText.text = "" + 0;
        coinText.text = "" + 0;
        pausehighScore.text = "" + Player.HighScore[2];
        gamehighScore.text = "" + Player.HighScore[2]; 
    }
    public void IncreaseScore(){
        currentScore += 10;
        scoreText.text = "" + currentScore;
        if(currentScore > Player.HighScore[2]){
            Player.HighScore[2] = currentScore;
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
        if(currentLife == 0){
            GameOver();
        }
    }
    public void IncreaseCoin(){
        currentCoin++;
        coinText.text = "" + currentCoin;
        Player.GoldCoins += currentCoin;
        player.SavePlayer();
    }

    public void RestartGame(){
        Time.timeScale = 1f;
        gameIsPaused = 0;
        SceneManager.LoadScene("Quiz");
    }
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        panelAlpha.SetActive(false);
        btnPause.interactable = true;
        Time.timeScale = 1f;
        gameIsPaused = 1;
    }
    public void PauseGame(){
        if(currentScore > Player.HighScore[2]){
            pausehighScore.text = "" + currentScore;
        }else
            pausehighScore.text = "" + Player.HighScore[2];
        pauseScore.text = "" + currentScore;
        pauseMenu.SetActive(true);
        panelAlpha.SetActive(true);
        btnPause.interactable = false;
        Time.timeScale = 0f;
        gameIsPaused = -1;
    }
    public void GameOver(){
        FindObjectOfType<AudioManager>().Play("Applause");  
        coinEarned.text = "" + currentCoin;
        gameOverScore.text = "" + currentScore;
        Player.GoldCoins += currentCoin;
        player.SavePlayer();
        gameOverMenu.SetActive(true);
        panelAlpha.SetActive(true);
        btnPause.interactable = false;
        Time.timeScale = 0f;
        gameIsPaused = -1;
    }
    public void DoubleCoinsClicked(){
        adsManager.ButtonType = "CatchDouble";
    }

    public void DoubleCoins(){
        FindObjectOfType<AudioManager>().Play("Coin");
        GameObject.Find("Button_Ad").GetComponent<Button>().interactable = false;
        currentCoin = currentCoin * 2;
        coinEarned.text = "" + currentCoin;
        Player.GoldCoins += currentCoin;
        player.SavePlayer();
        Time.timeScale = 0f;
    }   
    private void OnDestroy() {
        if(currentScore > Player.HighScore[2]){
            Player.HighScore[2] = currentScore;
            player.SavePlayer();
        }
        Time.timeScale = 1f;
        gameIsPaused = 0;
    }  
    private void OnApplicationPause(bool pauseStatus) {
       if(pauseStatus && !gameOverMenu.activeSelf)
            PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus == GameStatus.PLAYING && transPanel.alpha == 0)
        {
            currentTime -= Time.deltaTime;
            SetTime(currentTime);
        }
    }
    private void SetTime(float currentTime){
        TimeSpan time = TimeSpan.FromSeconds(currentTime);                       //set the time value
        timerText.text = time.ToString("ss");   //convert time to Time format

        if (currentTime <= 0)
        {
            GameOver();    
        }
    }
    void SelectQuestion(){
        int val = UnityEngine.Random.Range(0, questions.Count);
        selectedQuestion = questions[val];

        quizUI.SetQuestion(selectedQuestion);

        questions.RemoveAt(val);
    }
    public bool Answer(string answered){
        bool correctAnswer = false;
        if(answered == selectedQuestion.correctAns){
            correctAnswer = true;
            IncreaseScore();
            IncreaseCoin();
            FindObjectOfType<AudioManager>().Play("Life");  
        }else{
            DecreaseLife();
            FindObjectOfType<AudioManager>().Play("Poof");  
        }
        if(gameStatus == GameStatus.PLAYING){
            if(questions.Count > 0){
                Invoke("SelectQuestion", .4f);
            }else{
                GameOver();
            }
        }
       
        return correctAnswer;
    }
}
[System.Serializable]
public class Question{
    public string questionInfo;
    public QuestionType questionType;
    public OptionType optionType;
    public Sprite questionImg;
    public AudioClip questionAudio;
    public VideoClip questionVideo;
    public List<string> options;
    public List<Sprite> imgOptions;
    public string correctAns;
}
[System.Serializable]
public enum QuestionType{
    TEXT,
    IMAGE,
    VIDEO, 
    AUDIO
}
public enum OptionType{
    TEXT,
    IMAGE,
    VIDEO, 
    AUDIO
}
[SerializeField]
public enum GameStatus
{
    PLAYING,
    NEXT
}
