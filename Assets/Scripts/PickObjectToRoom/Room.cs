using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Room : MonoBehaviour, IDropHandler
{
    public AudioSource rightSound;
    public AudioSource wrongSound;

    private Level level;
    private List<GameObject> droppedObjList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
    }

    private void Update()
    {
        for (int i = 0; i < droppedObjList.Count; i++)
        {
            if (droppedObjList[i] != null)
            {
                bool isOnThisRoom = droppedObjList[i].GetComponent<DragObject>().IsInCorrectRoom();
                if (!isOnThisRoom && level.ObjectNumber() > 0)
                {
                    level.Undo();
                    droppedObjList.Remove(droppedObjList[i]);
                }
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.tag == gameObject.tag)
        {
            rightSound.Play();
            GameObject droppedObj = eventData.pointerDrag;
            droppedObj.GetComponent<DragObject>().CorrectRoom(true);
            //Debug.Log("in room");
            level.CountObject();
            droppedObjList.Add(droppedObj);
        }
        else
        {
            wrongSound.Play();
        }
    }
}
