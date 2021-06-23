using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountManager : MonoBehaviour
{
    [SerializeField] private int numberOfAnimalsSelected;
    [SerializeField] private string nextScene;
    [SerializeField] private GameObject popupWin;
    [SerializeField] private GameObject countUI;

    private SaveLoadFile slf;
    private static int time = 0;

    public static int Time { get => time; set => time = value; }

    // Start is called before the first frame update
    private void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
    }

    public string ConvertNumberToFrench()
    {
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
            case 10:
                temp = "dix";
                break;
            case 11:
                temp = "onze";
                break;
            case 12:
                temp = "douze";
                break;
            case 13:
                temp = "treize";
                break;
            case 14:
                temp = "quatorze";
                break;
            case 15:
                temp = "quinze";
                break;
            case 16:
                temp = "seize";
                break;
            case 17:
                temp = "dix-sept";
                break;
            case 18:
                temp = "dix-huit";
                break;
            case 19:
                temp = "dix-neuf";
                break;
            case 20:
                temp = "vingt";
                break;
            default:
                temp = "";
                break;
        }

        return temp;
    }

    public bool HandleCount(string numberText)
    {
        bool correctAns = false;
        string temp = ConvertNumberToFrench();

        if(temp.ToLower() == numberText.ToLower())
        {
            correctAns = true;
            if (nextScene != "" && nextScene != "TopicsNumberScene")
            {
                slf.SaveCurrentSceneCountNumber(nextScene);
            }
            else
            {
                slf.ResetGameCountNumber();
            }
            time = 0;
        }
        else
        {
            time++;
        }

        //Invoke("NextRound", 3f);
        return correctAns;
    }

    public void NextRound()
    {
        if(nextScene != "" && nextScene != "TopicsNumberScene")
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            if(!slf.CheckCompleteGame("GameCountNumber"))
            {
                //increase key
                slf.IncreaseKey();

                //complete game
                slf.CompleteGame("GameCountNumber");

                StartCoroutine(WinGame(5f));
            }    
        }
    }

    IEnumerator WinGame(float delaytime)
    {
        Instantiate(popupWin);

        yield return new WaitForSeconds(0.3f);
        countUI.SetActive(false);

        yield return new WaitForSeconds(delaytime);
        SceneManager.LoadScene("TopicsNumberScene");
    }
}

[System.Serializable]
class NumberUI
{
    public TMP_Text numberText;
    public Image numberImg;
}