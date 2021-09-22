using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //private int correctAns = 0;
    [SerializeField] StarRate starRateBar;
    [SerializeField] DataAnimalsScriptable dataNumber;
    [SerializeField] List<Card> cards;
    private string correctAns ="Un";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseCard(Button btn)
    {
        // get the script of the card(button) was clicked and pass to CheckAnswer
        Card cardClicked = btn.gameObject.GetComponent<Card>();
        CheckAnswer(cardClicked);
    }

    public void CheckAnswer(Card cardClicked)
    {
        // compare the answer of the card with the correct answer
        if (cardClicked.getCardValue().Equals(correctAns))
        {
            cardClicked.CardCorrectAnimation();
        }
        else { }
        // hide all the card
        foreach(Card card in cards)
        {
            card.HideCardAnimation();
        }
    }

    public void CreateCardData()
    {

    }
}
