using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DragAndDropControl : MonoBehaviour, IPointerDownHandler, 
                                IBeginDragHandler, IEndDragHandler, 
                                IDragHandler, IDropHandler
{
    [SerializeField] Canvas canvas;
    [SerializeField] Sprite answerBoxSprite;
    [SerializeField] Sentinel sentinel;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private bool droppedOnBox = false;
    private Vector3 defaultPos;
    private Image image;
    private Sprite originalSprite;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        defaultPos = GetComponent<RectTransform>().position;
        originalSprite = GetComponent<Image>().sprite;
    }

    public void SetToDefault()
    {
        ResetSprite();
        ResetPos();
        droppedOnBox = false;
    }

    private void ResetPos()
    {
        rectTransform.position = defaultPos;
    }

    private void ResetSprite()
    {
        gameObject.GetComponent<Image>().sprite = originalSprite;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 90);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        droppedOnBox = false;
        gameObject.GetComponent<Canvas>().sortingOrder = 10;
        ResetSprite();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        gameObject.GetComponent<Canvas>().sortingOrder = 1;
        StartCoroutine("Return");
    }

    IEnumerator Return()
    { 
        yield return new WaitForEndOfFrame();
        if (droppedOnBox == false)
        {
            ResetPos();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (sentinel.GetComponent<Sentinel>().AlertIssued())
        {
            sentinel.GetComponent<Sentinel>().SetShouldStopAlert(true);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }

    public void SetDroppedOnBox(bool setter)
    {
        droppedOnBox = setter;
    }

    public bool GetDroppedOnBox()
    {
        return droppedOnBox;
    }

    public void SetSpriteToAnswerBox()
    {
        gameObject.GetComponent<Image>().sprite = answerBoxSprite;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
    }
}
