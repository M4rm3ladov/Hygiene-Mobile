using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class QuizManager : MonoBehaviour
{
    [SerializeField]
    private List<Question> questions;
    private Question selectedQuestion;
    // Start is called before the first frame update
    void Start()
    {
        SelectQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SelectQuestion(){
        int val = Random.Range(0, questions.Count);
        selectedQuestion = questions[val];
    }
    void Answer(){

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
