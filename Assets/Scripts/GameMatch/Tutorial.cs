using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject correctForm, canvas;
    [SerializeField] SpriteRenderer[] animals;
    [SerializeField] Button btnBack;

    private bool moving = false;
    private bool selected = true;

    // Start is called before the first frame update
    void Start()
    {
        SetEnabled(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            //animation hand click
            selected = false;
            StartCoroutine(HandTutorial());
        }
        if (moving)
        {
            Debug.Log("moving" + moving);
            //canvas.gameObject.SetActive(false);
            gameObject.GetComponent<RectTransform>().position = Vector3.MoveTowards(gameObject.GetComponent<RectTransform>().position, new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z), 10 * Time.deltaTime);
            if (Vector2.Distance(gameObject.GetComponent<RectTransform>().position, correctForm.transform.position) < 0.2f)
            {
                moving = false;
                SetEnabled(true);
            }
        }
    }

    void SetEnabled(bool flag)
    {
        for(int i = 0; i < animals.Length; i++)
        {
            animals[i].GetComponent<BoxCollider2D>().enabled = flag;
        }
        btnBack.enabled = flag;
    }

    IEnumerator HandTutorial()
    {
        //animation hand click

        yield return new WaitForSeconds(3f);
        moving = true;
    }
}
