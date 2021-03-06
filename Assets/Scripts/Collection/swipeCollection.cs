using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipeCollection : MonoBehaviour
{
    public GameObject scrollbar;// imageContent;
    private float scroll_pos = 0;
    float[] pos;
    //private bool runIt = false;
    private float time;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        //if (runIt)
        //{
        //    //GecisiDuzenle(distance, pos, takeTheBtn);
        //    time += Time.deltaTime;

        //    if (time > 1f)
        //    {
        //        time = 0;
        //        runIt = false;
        //    }
        //}

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                //Debug.LogWarning("Current Selected Level " + i);
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                transform.GetChild(i).GetChild(0).GetComponent<Button>().interactable = true;
                transform.GetChild(i).GetChild(1).GetComponent<Button>().interactable = true;

                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        transform.GetChild(j).GetChild(0).GetComponent<Button>().interactable = false;
                        transform.GetChild(j).GetChild(1).GetComponent<Button>().interactable = false;
                    }
                }
            }
        }
    }
}
