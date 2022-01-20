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
    private GameObject optionsHolder;
    [SerializeField]
    private GameObject imgOptionsHolder;
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
    private List<Button> imgOptions;
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
        for (int i = 0; i < imgOptions.Count; i++)
        {
            Button imgButton = imgOptions[i];
            imgButton.onClick.AddListener(() => OnClick(imgButton));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetQuestion(Question question){
        this.question = question;
        if(question.optionType == OptionType.IMAGE){
            optionsHolder.SetActive(false);
            imgOptionsHolder.SetActive(true);
        }else if(question.optionType == OptionType.TEXT){
            optionsHolder.SetActive(true);
            imgOptionsHolder.SetActive(false);
        }
        switch(question.questionType){
            case QuestionType.TEXT:
                questionImage.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                questionImage.transform.parent.gameObject.SetActive(true);

                questionVideo.transform.gameObject.SetActive(false);        //deactivate questionVideo
                questionImage.transform.gameObject.SetActive(true);           //activate questionImg
                questionAudio.transform.gameObject.SetActive(false);   

                questionImage.sprite = question.questionImg;
                break;
            case QuestionType.VIDEO:
                ImageHolder();
                questionVideo.transform.parent.gameObject.SetActive(true);

                questionVideo.transform.gameObject.SetActive(true);         //activate questionVideo
                questionImage.transform.gameObject.SetActive(false);          //deactivate questionImg
                questionAudio.transform.gameObject.SetActive(false);        //deactivate questionAudio

                questionVideo.clip = question.questionVideo;
                questionVideo.Play();
                break;
            case QuestionType.AUDIO:
                ImageHolder();
                questionAudio.transform.parent.gameObject.SetActive(true);

                questionVideo.transform.gameObject.SetActive(false);        //deactivate questionVideo
                questionImage.transform.gameObject.SetActive(false);          //deactivate questionImg
                questionAudio.transform.gameObject.SetActive(true);   

                audioLength = question.questionAudio.length;
                StartCoroutine(PlayAudio());
                break;        
        }
        questionText.text = question.questionInfo;

        if(question.optionType == OptionType.IMAGE){
            List<Sprite> answerList = ShuffleList.ShuffleListItems<Sprite>(question.imgOptions);

            for(int i = 0; i < imgOptions.Count; i++){
                //imgOptions[i].GetComponentInChildren<Image>().sprite = answerList[i];
                Image[] target = imgOptions[i].GetComponentsInChildren<Image>();
                for(int j = 0; j < target.Length; j++)
                {
                    if(j == 1)
                        target[j].gameObject.GetComponentInChildren<Image>().sprite = answerList[i];
                }
                imgOptions[i].name = answerList[i].name;
                imgOptions[i].image.color = normalColor;
            }
        }else if(question.optionType == OptionType.TEXT){
            List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options); 

            for(int i = 0; i < options.Count; i++){
                options[i].GetComponentInChildren<Text>().text = answerList[i];
                options[i].name = answerList[i];
                options[i].image.color = normalColor;
            }
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
        if(!answered){
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if(val){
                StartCoroutine(BlinkImg(btn.image));
            }else{
                btn.image.color = wrongColor;
            }
        }
    }
    IEnumerator BlinkImg(Image img)
    {
        for (int i = 0; i < 2; i++)
        {
            img.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            img.color = correctColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
