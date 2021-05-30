using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountManager : MonoBehaviour
{
    [SerializeField] private int numberOfAnimalsSelected;

    // Start is called before the first frame update
    public bool HandleCount(string numberText)
    {
        bool correctAns = false;
        string temp;
        switch (numberOfAnimalsSelected)
        {
            case 0:
                temp = "zéro";
                break;
            case 1:
                temp = "un";
                break;
            case 2:
                temp = "deux";
                break;
            case 3:
                temp = "trois";
                break;
            case 4:
                temp = "quatre";
                break;
            case 5:
                temp = "cinq";
                break;
            case 6:
                temp = "six";
                break;
            case 7:
                temp = "sept";
                break;
            case 8:
                temp = "huit";
                break;
            case 9:
                temp = "neuf";
                break;
            default:
                temp = "";
                break;
        }
        if(temp.ToLower() == numberText.ToLower())
        {
            correctAns = true;
        }

        //Invoke("NextRound", 3f);
        return correctAns;
    }

    public void NextRound(string nextScene)
    {
        if(nextScene == "")
        {
            SceneManager.LoadScene("TopicsNumberScene");
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}

[System.Serializable]
class NumberUI
{
    public TMP_Text numberText;
    public Image numberImg;
}