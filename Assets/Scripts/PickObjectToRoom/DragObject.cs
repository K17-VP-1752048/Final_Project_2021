using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IBeginDragHandler, IPointerDownHandler, 
                        IEndDragHandler, IDragHandler
{
    [SerializeField] Canvas canvas;

    private RectTransform rectTransform;
    private Vector3 defaultPos;
    private CanvasGroup canvasGroup;
    private bool correctRoom = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultPos = GetComponent<RectTransform>().position;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        gameObject.GetComponent<Canvas>().sortingOrder = 10;
        correctRoom = false;
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
        if (correctRoom == false)
        {
            ResetPos();
        }
    }

    private void ResetPos()
    {
        rectTransform.position = defaultPos;
    }

    public void CorrectRoom(bool setter)
    {
        correctRoom = setter;
    }

    public bool IsInCorrectRoom()
    {
        return correctRoom;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //correctRoom = false;
    }
}
