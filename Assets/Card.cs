using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Animator cardAnimator;
    
    //storing the answer of each card
    [SerializeField] private string cardValue;

    // Start is called before the first frame update
    void Start()
    {
        cardAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CardCorrectAnimation()
    {
        StartCoroutine(CardAnimation(0.1f, "Corrected"));
    }

    public void HideCardAnimation()
    {
        StartCoroutine(CardAnimation(2f, "Hide"));
    }

    public void ShowCardAnimation()
    {
        StartCoroutine(CardAnimation(2f, "Show"));
    }

    IEnumerator CardAnimation(float delay, string triggerName)
    {
        yield return new WaitForSeconds(delay);
        cardAnimator.SetTrigger(triggerName);
    }

    public string getCardValue()
    {
        return cardValue;
    }
}
