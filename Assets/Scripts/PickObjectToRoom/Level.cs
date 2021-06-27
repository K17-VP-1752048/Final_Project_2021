﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject popupCanvas, getKeyRewardCanvas;
    [SerializeField] int objectInThisLvl;
    [SerializeField] string nextScene;

    [SerializeField] int objectNumber;
    private SaveLoadFile slf;
    private bool finished = false;
    private float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectNumber == objectInThisLvl)
        {
            if (nextScene != "TopicsHouseScene")
            {
                slf.SaveCurrentScenePickToRoom(nextScene);
                timeDelay = 2.5f;
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
                timeDelay = 3.5f;
            }
            StartCoroutine(LoadPopUpAndLoadScene(timeDelay));
        }
    }

    IEnumerator LoadPopUpAndLoadScene(float timeDelay)
    {
        popupCanvas.SetActive(true);
        yield return new WaitForSeconds(timeDelay);
        if (finished && getKeyRewardCanvas != null)
        {
            popupCanvas.GetComponentInChildren<Animator>().SetTrigger("Disappear");
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
}
