using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Room : MonoBehaviour, IDropHandler
{
    private Level level;
    private GameObject droppedObj = null;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
    }

    private void Update()
    {
        if (droppedObj != null) 
        {
            bool isOnThisRoom = droppedObj.GetComponent<DragObject>().IsInCorrectRoom();
            if (!isOnThisRoom && level.ObjectNumber() > 0)
            {
                level.Undo();
                droppedObj = null;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.tag == gameObject.tag)
        {
            droppedObj = eventData.pointerDrag;
            droppedObj.GetComponent<DragObject>().CorrectRoom(true);
            Debug.Log("in room");
            level.CountObject();
        }
    }
}
