using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField]
    private QuizManager quizManager;
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Image questionImage;
    [SerializeField]
    private VideoPlayer questionVideo;
    [SerializeField]
    private AudioSource questionAudio;
    [SerializeField]
    private List<Button> options;
    [SerializeField]
    private Color correctColor, wrongColor, normalColor;
    private Question question;
    private bool answered;
    private float audioLength;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake() {
        for (int i = 0; i < options.Count; i++)
        {
            Button localButton = options[i];
            localButton.onClick.AddListener(() => OnClick(localButton));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetQuestion(Question question){
        this.question = question;
        switch(question.questionType){
            case QuestionType.TEXT:
                questionImage.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                questionImage.transform.parent.gameObject.SetActive(true);

                questionImage.sprite = question.questionImg;
                break;
            case QuestionType.VIDEO:
                ImageHolder();
                questionVideo.transform.parent.gameObject.SetActive(true);

                questionVideo.clip = question.questionVideo;
                questionVideo.Play();
                break;
            case QuestionType.AUDIO:
                ImageHolder();
                questionAudio.transform.parent.gameObject.SetActive(true);

                audioLength = question.questionAudio.length;
                StartCoroutine(PlayAudio());
                break;        
        }
        questionText.text = question.questionInfo;

        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);

        for(int i = 0; i < options.Count; i++){
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalColor;
        }
        answered = false;
    }
    IEnumerator PlayAudio(){
        if(question.questionType == QuestionType.AUDIO){
            questionAudio.PlayOneShot(question.questionAudio);

            yield return new WaitForSeconds(audioLength + .5f);

            StartCoroutine(PlayAudio());
        }else{
            StopCoroutine(PlayAudio());
            yield return null;
        }
    }
    void ImageHolder(){
        questionImage.transform.parent.gameObject.SetActive(false);
        questionVideo.transform.parent.gameObject.SetActive(false);
        questionAudio.transform.parent.gameObject.SetActive(false);
    }
    private void OnClick(Button btn){
        answered = true;
        bool val = quizManager.Answer(btn.name);

        if(val){
            btn.image.color = correctColor;
        }else{
            btn.image.color = wrongColor;
        }
    }

}
