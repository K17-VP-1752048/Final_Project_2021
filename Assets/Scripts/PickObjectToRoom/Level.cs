using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject gameWinCanvas, getKeyRewardCanvas;
    [SerializeField] GameObject popupCanvas;
    [SerializeField] int objectInThisLvl;
    [SerializeField] string nextScene;

    [SerializeField] int objectNumber;
    private SaveLoadFile slf;
    private bool finished = false;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
        GetRandomPopUpIndex();
        Debug.Log(index);
    }

    // Update is called once per frame
    void Update()
    {
        if (objectNumber == objectInThisLvl)
        {
            if (nextScene != "TopicsHouseScene")
            {
                slf.SaveCurrentScenePickToRoom(nextScene);
                StartCoroutine(LoadNextScene());
            }
            else if (nextScene == "TopicsHouseScene")
            {
                if (!slf.CheckCompleteGame("GamePickToRoom"))
                {
                    //increase key
                    slf.IncreaseKey();

                    //complete game
                    slf.CompleteGame("GamePickToRoom");

                    this.finished = true;
                }
                slf.ResetGamePickToRoom();
                StartCoroutine(WinGame());
            }
        }
    }

    IEnumerator LoadNextScene()
    {
        GameObject popUpObject = popupCanvas.transform.GetChild(index).gameObject;
        popUpObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator WinGame()
    {
        gameWinCanvas.SetActive(true);
        yield return new WaitForSeconds(4f);
        if (finished && getKeyRewardCanvas != null)
        {
            gameWinCanvas.GetComponentInChildren<Animator>().SetTrigger("Disappear");
            getKeyRewardCanvas.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
        SceneManager.LoadScene(nextScene);
    }

    public int CountObject()
    {
        return objectNumber++;
    }

    public int Undo()
    {
        return objectNumber--;
    }

    public int ObjectNumber()
    {
        return objectNumber;
    }

    private void GetRandomPopUpIndex()
    {
        if(popupCanvas != null)
        {
            index = UnityEngine.Random.Range(0, popupCanvas.transform.childCount);
        }
    }
}
