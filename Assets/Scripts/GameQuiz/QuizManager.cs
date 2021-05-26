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
            SceneManager.LoadScene("TopicsAnimalsScene");
        }
        else
        {
            int val = Random.Range(0, questions.Count);
            selectedQuestion = questions[val];
            quizUI.SetQuestion(selectedQuestion);
            this.index = val;
        }
    }

    public bool Answer(string answered)
    {
        bool correctAns = false;
        if (answered == selectedQuestion.correctAns)
        {
            //YES
            correctAns = true;
            questions.RemoveAt(this.index);
        }
        else
        {
            //NO
        }

        Invoke("SelectQuestion", 3f);

        return correctAns;
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
    public Sprite answerImg;
    public AudioClip answerClip;
}

[System.Serializable]
public class AnswerUI
{
    public TMP_Text answerText;
    public Image answerImg;
    public Image speakImg;
}