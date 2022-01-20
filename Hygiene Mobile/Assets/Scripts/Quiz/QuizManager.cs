using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class QuizManager : MonoBehaviour
{
    [SerializeField]
    private QuizUI quizUI;
    [SerializeField]
    private QuizScriptable quizScriptable;
    private GameStatus gameStatus = GameStatus.NEXT;
    public GameStatus GameStatus { get { return gameStatus; } }
    private List<Question> questions;
    private Question selectedQuestion;
    // Start is called before the first frame update
    void Start()
    {
        questions = new List<Question>();
        questions.AddRange(quizScriptable.questions);
        
        SelectQuestion();
        gameStatus = GameStatus.PLAYING;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SelectQuestion(){
        int val = Random.Range(0, questions.Count);
        selectedQuestion = questions[val];

        quizUI.SetQuestion(selectedQuestion);

        questions.RemoveAt(val);
    }
    public bool Answer(string answered){
        bool correctAnswer = false;
        if(answered == selectedQuestion.correctAns){
            correctAnswer = true;
        }else{

        }
        if(gameStatus == GameStatus.PLAYING){
            if(questions.Count > 0){
                Invoke("SelectQuestion", .4f);
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
