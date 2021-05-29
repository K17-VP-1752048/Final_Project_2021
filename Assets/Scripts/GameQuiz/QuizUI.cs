using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private Image questionImg;
    [SerializeField] private List<AnswerUI> options;
    [SerializeField] private AudioClip bravo_audio;
    [SerializeField] private AudioClip fail_audio;

    private Question question;
    private Answer answer;
    private bool answered;

    // Start is called before the first frame update
    void Start()
    {
        question = new Question();
    }

    public void SetQuestion(Question question)
    {
        this.question = question;

        /*switch (question.questionType)
        {
            case QuestionType.TEXT:
                questionImg.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                questionImg.transform.gameObject.SetActive(true);
                questionImg.sprite = question.questionImg;
                break;
        }*/
        questionText.text = question.questionInfo;
        questionImg.sprite = question.questionImg;
        questionImg.preserveAspect = true;

        //shuffle the list of options
        List<Answer> ansOptions = ShuffleList.ShuffleListItems<Answer>(question.options);

        for(int i = 0; i < options.Count; i++)
        {
            options[i].answerText.text      = ansOptions[i].answerText;
            options[i].answerImg.sprite     = ansOptions[i].answerSprite;
            options[i].answerImg.preserveAspect = true;
            options[i].answerImg.color      = new Color(0.854902f, 0.9176471f, 0.6039216f, 1);
            options[i].answerImg.GetComponent<AudioSource>().clip = ansOptions[i].answerClip;
            //options[i].speakImg.GetComponent<AudioSource>().clip = options[i].answerImg.GetComponent<AudioSource>().clip;
        }
        
        answered = false;
    }

    /*void ImageHolder()
    {
        questionImg.transform.parent.gameObject.SetActive(true);
        questionImg.transform.gameObject.SetActive(false);
    }*/

    //Change the color of an option when selected 
    public void ChooseOption(Image opt)
    {
        for (int i = 0; i < options.Count; i++)
        {
            options[i].answerImg.color = new Color(0.855f, 0.918f, 0.604f, 1);
        }
        StartCoroutine(BlinkSelectedImg(opt));
    }

    //handle button verifier
    public void HandleOptionChoose(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            if(child.GetComponentInChildren<Image>().color == new Color(0.5962264f, 0.745283f, 0, 1))
            {
                HandleQuestion(child.GetComponentInChildren<Image>());
                break;
            }
        }
    }

    public void HandleQuestion(Image ansImg)
    {
        if (!answered)
        {
            answered = true;
            bool val = quizManager.Answer(ansImg.GetComponentInChildren<TMP_Text>().text);
            if (val)
            {
                //set color to correct
                StartCoroutine(BlinkCorrectImg(ansImg));
            }
            else
            {
                //set color to incorrect
                StartCoroutine(BlinkWrongImg(ansImg));
            }
        }
    }

    //this give blink effect [if needed use or dont use]
    IEnumerator BlinkSelectedImg(Image img)
    {
        img.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        img.color = new Color(0.5962264f,0.745283f,0,1);
        img.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(img.GetComponent<AudioSource>().clip.length + 2f);
    }

    //this give blink effect [if needed use or dont use]
    IEnumerator BlinkWrongImg(Image img)
    {
        img.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        img.color = Color.red;
        //img.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().clip = fail_audio;
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length + 2f);
    }

    //this give blink effect [if needed use or dont use]
    IEnumerator BlinkCorrectImg(Image img)
    {
        img.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        img.color = Color.green;
        //img.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().clip = bravo_audio;
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length + 2f);
    }

    public void HandleSpeakOption(Image speakImg)
    {
        speakImg.GetComponent<AudioSource>().Play();
    }
}

