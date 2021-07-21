using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class CountUI : MonoBehaviour
{
    [SerializeField] private List<NumberUI> options;
    [SerializeField] private CountManager countManager;
    [SerializeField] private GameObject showRes;
    [SerializeField] private AudioClip bravo_audio;
    [SerializeField] private AudioClip fail_audio;
    [SerializeField] private TMP_Text questionInfoText;
    [SerializeField] private TMP_Text questionAnimalText;
    [SerializeField] private Image warningImg;
    [SerializeField] private RectTransform guessText;
    [SerializeField] private Image check;
    [SerializeField] private GameObject handguideSelectedNumber, handguideCheck;

    private int indexCorrectAns = -1;
    private SaveLoadFile slf;

    // Start is called before the first frame update
    void Start()
    {
        //initiate
        slf = gameObject.AddComponent<SaveLoadFile>();

        //Tutorial Number_Count1 for beginners (only 1 time)
        if (handguideSelectedNumber != null && handguideCheck != null && !slf.CheckCompleteGame("GameCountNumber"))
        {
            //disabled images
            SetEnabled(false);

            handguideSelectedNumber.SetActive(true);
            options[0].numberImg.GetComponent<BoxCollider2D>().enabled = true;
            //StartCoroutine(Tutorial(handguideSelectedNumber));
        }
    }

    void Update()
    { 
        if(this.indexCorrectAns != -1)
        {
            SetEnabled(false);
            options[this.indexCorrectAns].numberImg.GetComponent<RectTransform>().position = Vector3.MoveTowards(options[this.indexCorrectAns].numberImg.GetComponent<RectTransform>().position, new Vector3(guessText.position.x - 0.45f, guessText.position.y, guessText.position.z), 10 * Time.deltaTime);
            Vector2 vector = new Vector2(guessText.position.x - 0.45f, guessText.position.y);

            if (Vector2.Distance(options[this.indexCorrectAns].numberImg.GetComponent<RectTransform>().position, vector) < 0.1f)
            {
                SetEnabled(false);
                StartCoroutine(ShowPopup(2f, options[this.indexCorrectAns].numberImg));

                this.indexCorrectAns = -1;
            }
        }

        //tutorial Number_Count1 for beginners
        if (!slf.CheckCompleteGame("GameCountNumber"))
        {
            if (options[0].numberImg.color == new Color(0.8823529f, 0.8862745f, 0.6509804f, 1) && handguideSelectedNumber != null)
            {
                handguideSelectedNumber.GetComponent<Animator>().SetTrigger("SingleClick");
            }

            if (options[0].numberImg.color == new Color(1, 1, 0, 1) && (handguideSelectedNumber != null || handguideCheck != null))
            {
                Destroy(handguideSelectedNumber);
                SetEnabled(false);
                handguideCheck.SetActive(true);
                handguideCheck.GetComponent<Animator>().SetTrigger("SingleClick");
                check.GetComponent<BoxCollider2D>().enabled = true;
            }

            if (check.color == new Color(0.5962264f, 0.745283f, 0, 1) && (handguideSelectedNumber != null || handguideCheck != null))
            {
                Destroy(handguideCheck);
            }
        }
    }

    public void ChooseOption(Image opt)
    {
        for (int i = 0; i < options.Count; i++)
        {
            options[i].numberImg.color = new Color(0.8823529f, 0.8862745f, 0.6509804f, 1);
        }
        StartCoroutine(BlinkSelectedImg(opt));
    }

    //handle button verifier
    public void HandleOptionChoose(GameObject obj)
    {
        bool selected = false;
        foreach (Transform child in obj.transform)
        {
            if (child.GetComponentInChildren<Image>().color == new Color(1, 1, 0, 1))
            {
                selected = true;
                HandleQuestion(child.GetComponentInChildren<Image>());
                break;
            }
        }
        //not choose any question
        if (!selected)
        {
            StartCoroutine(Warning(1f));
        }
    }

    public void HandleQuestion(Image ansImg)
    {
        bool val = countManager.HandleCount(ansImg.GetComponentInChildren<TMP_Text>().text);
        if (val)
        {
            //set color to correct
            StartCoroutine(BlinkCorrectImg(ansImg));
        }
        else
        {
            //set color to incorrect
            StartCoroutine(BlinkWrongImg(ansImg));
        }
    }

    //this give blink effect [if needed use or dont use]
    IEnumerator BlinkSelectedImg(Image img)
    {
        img.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        img.color = new Color(1, 1, 0, 1);
        img.GetComponent<AudioSource>().Play();
        //yield return new WaitForSeconds(img.GetComponent<AudioSource>().clip.length + 0.2f);
    }

    //this give blink effect [if needed use or dont use]
    IEnumerator BlinkWrongImg(Image img)
    {
        SetEnabled(false);

        img.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        img.color = Color.red;
        //img.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().clip = fail_audio;
        gameObject.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(0.5f);
        img.color = new Color(0.8823529f, 0.8862745f, 0.6509804f, 1);

        yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
        SetEnabled(true);
    }

    //this give blink effect [if needed use or dont use]
    IEnumerator BlinkCorrectImg(Image img)
    {
        SetEnabled(false);
        img.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        img.color = Color.green;
        //img.GetComponent<AudioSource>().Play();

        StartCoroutine(MoveCorrectAnswer(2f));
    }

    //Move the correct answer
    IEnumerator MoveCorrectAnswer(float delaytime)
    {
        SetEnabled(false);
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < options.Count; i++)
        {
            if (options[i].numberImg.GetComponentInChildren<TMP_Text>().text.ToLower() == countManager.ConvertNumberToFrench().ToLower())
            {
                this.indexCorrectAns = i;
                break;
            }
        }

        SetEnabled(true);
    }

    IEnumerator ShowPopup(float delaytime, Image img)
    {
        Debug.Log("showpopup");
        SetEnabled(false);
        yield return new WaitForSeconds(delaytime);
        showRes.SetActive(true);
        showRes.GetComponent<AudioSource>().clip = bravo_audio;
        showRes.GetComponent<AudioSource>().Play();

        //yield return new WaitForSeconds(1f);
        showRes.GetComponentInChildren<Image>().GetComponentInChildren<TMP_Text>().text = questionInfoText.text + " " + img.GetComponentInChildren<TMP_Text>().text.ToLower() + " " + questionAnimalText.text;
        showRes.GetComponentInChildren<Image>().GetComponentInChildren<TMP_Text>().color = Color.blue;

        yield return new WaitForSeconds(showRes.GetComponent<AudioSource>().clip.length + 0.2f);
        countManager.NextRound();
        showRes.SetActive(false);
        SetEnabled(true);
    }

    IEnumerator Warning(float delayTime)
    {
        SetEnabled(false);
        warningImg.gameObject.SetActive(true);

        yield return new WaitForSeconds(delayTime);

        warningImg.gameObject.SetActive(false);
        SetEnabled(true);
    }

    /*IEnumerator Tutorial(GameObject obj)
    {
        obj.GetComponent<Animator>().SetTrigger("SingleClick");
        yield return new WaitForSeconds(2f);
    }*/

    public void SetActive(bool flag)
    {
        //set active
        for (int i = 0; i < options.Count; i++)
        {
            options[i].numberImg.gameObject.SetActive(flag);
        }
        check.gameObject.SetActive(flag);
    }

    public void SetEnabled(bool flag)
    {
        //enabled images
        for (int i = 0; i < options.Count; i++)
        {
            options[i].numberImg.GetComponent<BoxCollider2D>().enabled = flag;
        }
        check.GetComponent<BoxCollider2D>().enabled = flag;
    }
}
