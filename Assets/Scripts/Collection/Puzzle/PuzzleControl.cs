using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleControl : MonoBehaviour
{
    [SerializeField] string puzzleName;
    [SerializeField] int orderNumber;
    [SerializeField] GameObject winCanvas;
    [SerializeField] private GameObject guideCanvas;

    public static bool continu, win;

    private static new string name;
    private bool playsound = false;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
        continu = true;
        if(guideCanvas != null)
        {
            StartCoroutine(showGuideHand());
        }
        name = puzzleName;
    }

    public static void CheckAnswer()
    {
        bool flag = true;
        for (int i = 0; i < 28; i++)
        {
            Transform pic = GameObject.Find("puzzle_" + name + "_" + i).GetComponent<Transform>();
            if (pic.rotation.z != 0)
            {
                flag = false;
                break;
            }
        }

        if (flag)
        {
            win = true;
        }
    }

    void Update()
    {
        if (win && continu)
        {
            continu = false;
        }
        if(!continu)
        {
            if (KeepSoundPlay.state && !playsound)
            {
                playsound = true;
                GetComponent<AudioSource>().Play();
            }
            StartCoroutine(showWinCanvas());
        }
    }

    IEnumerator showWinCanvas()
    {
        
        winCanvas.SetActive(true);

        yield return new WaitForSeconds(1.8f);
        //yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        SceneManager.LoadScene("Image" + orderNumber);
    }

    IEnumerator showGuideHand()
    {
        guideCanvas.SetActive(true);
        yield return new WaitForSeconds(2f);
        guideCanvas.SetActive(false);
    }
}