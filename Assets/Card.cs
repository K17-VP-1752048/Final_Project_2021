using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    
    //storing the answer of each card
    [SerializeField] private string cardValue;

    private Vector3 currentCardPos;
    private Vector3 startCardPos;

    // Start is called before the first frame update
    void Start()
    {
        startCardPos = GetComponent<RectTransform>().anchoredPosition;
        Debug.Log(startCardPos.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CardCorrectAnimation()
    {
        LeanTween.scale(gameObject.GetComponent<RectTransform>(),
            new Vector3(1.2f, 1.2f, 1.2f), 1f)
            .setEasePunch();
    }

    public void CardWrongAnimation()
    {
        
    }

    public void HideCardAnimation()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), -600f, 0.5f)
            .setDelay(1f).setEase(LeanTweenType.linear);
        
    }

    public void ShowCardAnimation()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), startCardPos.y, 0.5f)
            .setDelay(2f).setEase(LeanTweenType.linear);
    }

    public string getCardValue()
    {
        return cardValue;
    }
    public void setCardValue(string value)
    {
        cardValue = value;
    }
}
