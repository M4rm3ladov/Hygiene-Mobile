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
    private List<Question> questions;
    private Question selectedQuestion;
    // Start is called before the first frame update
    void Start()
    {
        questions = quizScriptable.questions;
        SelectQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SelectQuestion(){
        int val = Random.Range(0, questions.Count);
        selectedQuestion = questions[val];

        quizUI.SetQuestion(selectedQuestion);
    }
    public bool Answer(string answered){
        bool correctAnswer = false;
        if(answered == selectedQuestion.correctAns){
            correctAnswer = true;
        }else{

        }
        Invoke("SelectQuestion", .4f);
        return correctAnswer;
    }
}
[System.Serializable]
public class Question{
    public string questionInfo;
    public QuestionType questionType;
    public Sprite questionImg;
    public AudioClip questionAudio;
    public VideoClip questionVideo;
    public List<string> options;
    public string correctAns;
}
[System.Serializable]
public enum QuestionType{
    TEXT,
    IMAGE,
    VIDEO, 
    AUDIO
}
