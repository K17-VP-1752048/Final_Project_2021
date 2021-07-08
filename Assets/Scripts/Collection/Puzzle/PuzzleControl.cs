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
    public static bool continu, win;

    private static new string name;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
        continu = true;
        winCanvas.SetActive(false);
        GameObject.Find("Trans").GetComponent<Image>().enabled = false;
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
            GameObject.Find("Trans").GetComponent<Image>().enabled = true;
            GameObject.Find("PanelPuzzle").SetActive(false);
            winCanvas.SetActive(true);
        }
        if(!continu)
        {
            StartCoroutine(loadToCollection());
        }
    }

    IEnumerator loadToCollection()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Image" + orderNumber);
    }
}