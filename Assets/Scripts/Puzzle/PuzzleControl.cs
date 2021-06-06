using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleControl : MonoBehaviour
{
    [SerializeField] public string puzzleName;
    public static bool win;
    private static new string name;

    private Text winText;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
        winText = GameObject.Find("TextWin").GetComponent<Text>();
        winText.enabled = false;
        name = puzzleName;
    }

    public static void CheckAnswer()
    {
        //bool flag = true;
        for (int i = 0; i < 28; i++)
        {
            Transform pic = GameObject.Find("puzzle_" + name + "_" + i).GetComponent<Transform>();
            if (pic.rotation.z != 0)
            {
                break;
            }
            win = true;
        }

        //if(flag)
        //{
        //    win = true;
        //}
    }

    void Update()
    {
        if(win)
            winText.enabled = true;
    }
}
