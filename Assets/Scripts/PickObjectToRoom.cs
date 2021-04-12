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

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, 
                                                                mousePos.y - startPosY, 
                                                                this.gameObject.transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(this.transform.localPosition.x - room1.transform.localPosition.x) <= 3.8f &&
            Mathf.Abs(this.transform.localPosition.y - room1.transform.localPosition.y) <= 2f)
        {
            /*this.transform.localPosition = new Vector3(correctRoom.transform.localPosition.x,
                                                       correctRoom.transform.localPosition.y,
                                                       correctRoom.transform.localPosition.z);*/
            Debug.Log("In room 1");
            if (tag == room1.tag)
            {
                Debug.Log("Is in the correct room");
            }
        }
        else if (Mathf.Abs(this.transform.localPosition.x - room2.transform.localPosition.x) <= 3.8f &&
                 Mathf.Abs(this.transform.localPosition.y - room2.transform.localPosition.y) <= 2f)
        {
            Debug.Log("In room 2");
            if (tag == room2.tag)
            {
                Debug.Log("Is in the correct room");
            }
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }
}
