using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleControl : MonoBehaviour
{
    [SerializeField] public string puzzleName;
    public static bool continu, win;

    private static new string name;
    private Canvas winCanvas;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
        continu = true;
        winCanvas = GameObject.Find("CanvasReussite").GetComponent<Canvas>();
        winCanvas.enabled = false;
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
            winCanvas.enabled = true;
        }
        if(!continu)
        {
            StartCoroutine(loadToCollection());
            if(Input.touchCount > 0)
            {
                SceneManager.LoadScene("Scenes/CollectionScene");
            }
        }
    }

    IEnumerator loadToCollection()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Scenes/CollectionScene");
    }
}