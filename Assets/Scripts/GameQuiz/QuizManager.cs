using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizDataScriptable quizData;

    private List<Question> questions;
    private Question selectedQuestion;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        questions = new List<Question>(quizData.questions);
        SelectQuestion();
    }

    void SelectQuestion()
    {
        if (questions.Count <= 0)
        {
            StartCoroutine(NextRound(3f));
            //SceneManager.LoadScene("TopicsAnimalsScene");
        }
        else
        {
            int val = Random.Range(0, questions.Count);
            selectedQuestion = questions[val];
            quizUI.SetQuestion(selectedQuestion);
            this.index = val;
        }
    }

    public int Answer(string answered)
    {
        int correctAns = 0;
        float delayTime = 0;
        if (answered == selectedQuestion.correctAns && questions.Count > 1)
        {
            //YES
            correctAns = 1;
            questions.RemoveAt(this.index);
            delayTime = 3f;
        }
        else if(answered == selectedQuestion.correctAns && questions.Count <= 1)
        {
            correctAns = -1;
            questions.RemoveAt(this.index);
            delayTime = 3f;
        }
        else
        {
            correctAns = 0;
            delayTime = 1f;
        }

        Invoke("SelectQuestion", delayTime);

        return correctAns;
    }

    IEnumerator NextRound(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("TopicsAnimalsScene");
    }
}

[System.Serializable]
public class Question
{
    public string questionInfo;
    public Sprite questionImg;
    public List<Answer> options;
    public string correctAns;
}

[System.Serializable]
public class Answer
{
    public string answerText;
    public Sprite answerSprite;
    public AudioClip answerClip;
}

[System.Serializable]
public class AnswerUI
{
    public TMP_Text answerText;
    public Image answerImg;
    public Image speakImg;
}