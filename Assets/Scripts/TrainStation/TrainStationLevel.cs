using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainStationLevel : MonoBehaviour
{
    [SerializeField] int totalNumber;
    [SerializeField] GameObject popup;
    [SerializeField] string nextLevel;

    // for debugging
    [SerializeField] int count = 0;
    [SerializeField] bool allNumberInPlace = false;
    [SerializeField] bool popupText = false;
    [SerializeField] bool loadNextLvl = false;

    // Update is called once per frame
    void Update()
    {
        if (count == totalNumber)
        {
            allNumberInPlace = true;
        }
        if (popupText)
        {
            popup.SetActive(true);
        }
        if (loadNextLvl)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    public void Count()
    {
        count++;
    }

    public bool AllNumberIsInPlace()
    {
        return allNumberInPlace;
    }

    public void TogglePopupText(bool setter)
    {
        popupText = setter;
    }

    public void LoadNextLevel(bool setter)
    {
        loadNextLvl = setter;
    }
}
