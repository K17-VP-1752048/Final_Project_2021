using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject correctForm;
    [SerializeField] private SpriteRenderer[] animals; //gameMatch
    //[SerializeField] Button btnBack;
    [SerializeField] private GameObject trailFX;
    [SerializeField] private string selectedTopic;
    [SerializeField] private float time, distance;

    private bool moving = false;
    private bool selected = true;

    // Start is called before the first frame update
    void Start()
    {
        SetEnabled(false);
        //trailFX.transform.position = gameObject.GetComponent<RectTransform>().position;
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
            gameObject.GetComponent<RectTransform>().position = Vector3.MoveTowards(gameObject.GetComponent<RectTransform>().position, new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z), time * Time.deltaTime);
            // move trail when hand move
            trailFX.transform.position = gameObject.GetComponent<RectTransform>().position;
            if (Vector2.Distance(gameObject.GetComponent<RectTransform>().position, correctForm.transform.position) < distance)
            {
                moving = false;
                StartCoroutine(EndofTutorial());
            }
        }
    }

    void SetEnabled(bool flag)
    {
        for(int i = 0; i < animals.Length; i++)
        {
            animals[i].GetComponent<BoxCollider2D>().enabled = flag;
        }
        //btnBack.enabled = flag;
    }

    IEnumerator HandTutorial()
    {
        if(selectedTopic == "GamePickToRoom")
        {
            // click 1 lan thi dung cai dong nay
            gameObject.GetComponent<Animator>().SetTrigger("SingleClick");
            yield return new WaitForSeconds(2f);
        }

        //animation hand click
        gameObject.GetComponent<Animator>().SetTrigger("PressHold");
        yield return new WaitForSeconds(1.5f);
        moving = true;
    }

    IEnumerator EndofTutorial()
    {
        //animation hand click
        gameObject.GetComponent<Animator>().SetTrigger("Release");
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        Destroy(trailFX);
        SetEnabled(true);
    }
}
