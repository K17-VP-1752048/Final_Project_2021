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

    private int indexCorrectAns = -1;

    // Start is called before the first frame update
    void Start()
    {
        //enabled images
        /*for (int i = 0; i < options.Count; i++)
        {
            options[i].numberImg.GetComponent<BoxCollider2D>().enabled = true;
        }
        check.GetComponent<BoxCollider2D>().enabled = false;*/
    }

    void Update()
    {
        if (CountManager.Time >= 3)
        {
            //disabled images
            for (int i = 0; i < options.Count; i++)
            {
                options[i].numberImg.GetComponent<BoxCollider2D>().enabled = false;
            }
            check.GetComponent<BoxCollider2D>().enabled = false;

            StartCoroutine(CircleCorrectAnswer(2f));
            CountManager.Time = 0;
        }

        if(this.indexCorrectAns != -1)
        {
            options[this.indexCorrectAns].numberImg.GetComponent<RectTransform>().position = Vector3.MoveTowards(options[this.indexCorrectAns].numberImg.GetComponent<RectTransform>().position, new Vector3(guessText.position.x - 0.4f, guessText.position.y, guessText.position.z), 10 * Time.deltaTime);
            if (Vector2.Distance(options[this.indexCorrectAns].numberImg.GetComponent<RectTransform>().position, guessText.position) < 0.2f)
            {
                this.indexCorrectAns = -1;
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

    //Circle the correct answer
    IEnumerator CircleCorrectAnswer(float delaytime)
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < options.Count; i++)
        {
            if (options[i].numberImg.GetComponentInChildren<TMP_Text>().text.ToLower() == countManager.ConvertNumberToFrench().ToLower())
            {
                this.indexCorrectAns = i;
                break;
            }
        }

        yield return new WaitForSeconds(delaytime);
        showRes.SetActive(true);
        showRes.GetComponentInChildren<Image>().GetComponentInChildren<TMP_Text>().text = "Vous n'avez pas répondu correctement!!!";
    }

    //this give blink effect [if needed use or dont use]
    IEnumerator BlinkWrongImg(Image img)
    {
        img.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        img.color = Color.red;
        //img.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().clip = fail_audio;
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        img.color = new Color(0.8823529f, 0.8862745f, 0.6509804f, 1);
        yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
    }

    //this give blink effect [if needed use or dont use]
    IEnumerator BlinkCorrectImg(Image img)
    {
        img.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        img.color = Color.green;
        //img.GetComponent<AudioSource>().Play();
        showRes.SetActive(true);
        showRes.GetComponent<AudioSource>().clip = bravo_audio;
        showRes.GetComponent<AudioSource>().Play();
        //yield return new WaitForSeconds(1f);
        showRes.GetComponentInChildren<Image>().GetComponentInChildren<TMP_Text>().text = questionInfoText.text + " " + img.GetComponentInChildren<TMP_Text>().text.ToLower() + " " + questionAnimalText.text;
        showRes.GetComponentInChildren<Image>().GetComponentInChildren<TMP_Text>().color = Color.blue;
    }

    IEnumerator Warning(float delayTime)
    {
        warningImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(delayTime);
        warningImg.gameObject.SetActive(false);
    }
}
