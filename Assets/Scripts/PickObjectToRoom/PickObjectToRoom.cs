using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjectToRoom : MonoBehaviour
{
    [SerializeField] GameObject room1;
    [SerializeField] GameObject room2;

    private bool moving;
    private float startPosX;
    private float startPosY;
    private Vector3 resetPosition;
    private Level level;

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = this.transform.position;
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, 
                                                                mousePos.y - startPosY, 
                                                                this.gameObject.transform.position.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(this.transform.position.x - room1.transform.position.x) <= 3.8f &&
            Mathf.Abs(this.transform.position.y - room1.transform.position.y) <= 2f &&
            tag == room1.tag)
        {
            /*this.transform.localPosition = new Vector3(correctRoom.transform.localPosition.x,
                                                       correctRoom.transform.localPosition.y,
                                                       correctRoom.transform.localPosition.z);*/
            Debug.Log("In room 1");
            level.CountObject();
        }
        else if (Mathf.Abs(this.transform.position.x - room2.transform.position.x) <= 3.8f &&
                 Mathf.Abs(this.transform.position.y - room2.transform.position.y) <= 2f &&
                 tag == room2.tag)
        {
            Debug.Log("In room 2");
            level.CountObject();
        }
        else
        {
            this.transform.position = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
            if (level.ObjectNumber() > 0)
            {
                level.Undo();
            }
        }
    }
}
