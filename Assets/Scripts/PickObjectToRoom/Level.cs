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

    private int objectNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectNumber == objectInThisLvl)
        {
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
