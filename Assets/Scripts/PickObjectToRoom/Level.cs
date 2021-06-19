using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject popupCanvas;
    [SerializeField] int objectInThisLvl;
    [SerializeField] string nextScene;

    [SerializeField] int objectNumber;
    private SaveLoadFile slf;

    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectNumber == objectInThisLvl && nextScene != "TopicsHouseScene")
        {
            slf.SaveCurrentScenePickToRoom(nextScene);
            ShowPopup();
        }
        else if (objectNumber == objectInThisLvl && nextScene == "TopicsHouseScene") 
        {
            slf.ResetGamePickToRoom();
            ShowPopup();
        }
        if (popupCanvas.activeSelf && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    private void ShowPopup()
    {
        popupCanvas.SetActive(true);
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
