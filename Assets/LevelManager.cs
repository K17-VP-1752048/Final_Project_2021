using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //private int correctAns = 0;
    [SerializeField] StarRate starRateBar;
    [SerializeField] List<GameObject> cards;
    [SerializeField] VocabularyScriptable dataVocab; // scriptable object store number vocabs
    [SerializeField] int numberOfRounds = 3;
    [SerializeField] TMP_Text questionText;

    [SerializeField] int orderOfWord = 0; // index of vocab from scriptable object (Debug only)
    [SerializeField] int score = 0;
    private List<Vocabulary> vocabList; // list of vocab use in game
    private Vocabulary correctAnswer;
    private int currentRound = 0;
    // Start is called before the first frame update
    void Start()
    {
        vocabList = new List<Vocabulary>();
        InitializeGameData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeGameData()
    {
        CreateCardData();
        ShuffleData();
        AssignDataToCards();
        ShowQuestion();
    }

    public void CreateCardData()
    {   
        // get the vocabulary index in order from the scriptable object and add to vocabList
        correctAnswer = dataVocab.vocabularies[orderOfWord];
        vocabList.Add(correctAnswer);
        
        // get two random vocabulary from the scriptable object and add to vocabList
        for(int i = 1; i < cards.Count; i++)
        {
            int random = Random.Range(0, dataVocab.vocabularies.Count);
            while (vocabList.Contains(dataVocab.vocabularies[random]))
            {
                random = Random.Range(0, dataVocab.vocabularies.Count);
            }
            vocabList.Add(dataVocab.vocabularies[random]);
        }
    }
    public void ShuffleData()
    {
        // shuffle the vocabList
        for(int i = 0; i < vocabList.Count; i++)
        {
            int random = Random.Range(i, vocabList.Count);
            Vocabulary tmp = vocabList[i];
            vocabList[i] = vocabList[random];
            vocabList[random] = tmp;
        }
    }

    public void AssignDataToCards()
    {
        // assign image and vocab_text from vocabList to the cards
        for(int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.GetChild(0).GetComponent<Image>().sprite = vocabList[i].sprite;
            cards[i].GetComponent<Card>().setCardValue(vocabList[i].voca_text);
        }
    }

    public void ShowQuestion()
    {
        questionText.text = correctAnswer.voca_text;
    }

    public void ChooseCard(Button btn)
    {
        // get the script of the card(button) was clicked and pass to CheckAnswer
        Card cardClicked = btn.gameObject.GetComponent<Card>();
        HandleAnswer(cardClicked);
    }

    public void HandleAnswer(Card cardClicked)
    {
        // compare the answer of the card with the correct answer
        if (cardClicked.getCardValue().Equals(questionText.text))
        {
            EarnStar();
            cardClicked.CardCorrectAnimation();
        }
        else {
            cardClicked.CardWrongAnimation();
        }

        foreach (GameObject card in cards)
        {
            card.GetComponent<Card>().HideCardAnimation();
        }

        currentRound++;

        if(currentRound < numberOfRounds)
        {
            ClearCardData();
            Invoke("InitializeGameData", 1.5f);

            foreach (GameObject card in cards)
            {
                card.GetComponent<Card>().ShowCardAnimation();
            }
        }
    }
    
    public void ClearCardData()
    {
        // clear vocabList and move to the next word 
        orderOfWord++;
        vocabList.Clear();
    }

    public void EarnStar()
    {
        score++;
        float percentage = (float)score / numberOfRounds;
        Debug.Log(percentage);
        if(percentage == 1f)
        {
            starRateBar.UpdateStarRate(3);
        }
        else if(percentage >= 0.6f && percentage < 1f)
        {
            starRateBar.UpdateStarRate(2);
        }
        else if(percentage >= 0.3f && percentage < 0.6f)
        {
            starRateBar.UpdateStarRate(1);
        }
    }
}
