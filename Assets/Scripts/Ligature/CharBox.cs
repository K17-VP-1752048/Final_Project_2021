using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharBox : MonoBehaviour, IDropHandler
{
    private Vector3 correctPos;
    private GameObject droppedCharacter;
    private Color c;

    void Start()
    {
        correctPos = gameObject.GetComponent<RectTransform>().position;
        c = gameObject.GetComponent<Image>().color;
        droppedCharacter = null;
    }

    void Update()
    {
        if (droppedCharacter != null)
        {
            bool isStillOnThisBox = droppedCharacter.GetComponent<DragAndDropControl>().GetDroppedOnBox();
            if (!isStillOnThisBox)
            {
                droppedCharacter = null;
                SetTransparency(1);
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GetComponent<AudioSource>().Play();
            droppedCharacter = eventData.pointerDrag;
            droppedCharacter.GetComponent<RectTransform>().position = correctPos;
            droppedCharacter.GetComponent<DragAndDropControl>().SetDroppedOnBox(true);
            droppedCharacter.GetComponent<DragAndDropControl>().SetSpriteToAnswerBox();
            SetTransparency(0);
        }
    }

    private void SetTransparency(int trans)
    {
        c.a = trans;
        gameObject.GetComponent<Image>().color = c;
    }

    // return value: 
    //-1 means this box is still empty
    // 0 means the character does not match
    // 1 means the character is match
    public int Check()
    {
        if (droppedCharacter != null)
        {
            if (gameObject.tag == droppedCharacter.tag)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        return -1;
    }

    public void SetToDefault()
    {
        if (droppedCharacter != null)
        {
            droppedCharacter.GetComponent<DragAndDropControl>().SetToDefault();
            SetTransparency(1);
        }
    }
}
