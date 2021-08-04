using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainStationLevel : MonoBehaviour
{
    [SerializeField] int totalNumber;
    [SerializeField] GameObject popUpCanvas;
    [SerializeField] string nextLevel;
    [SerializeField] Train train;
    [SerializeField] private GameObject gameWinCanvas;
    [SerializeField] private GameObject getKeyRewardCanvas;
    [SerializeField] private float timeTransition = 4f;

    // for debugging
    [SerializeField] int count = 0;
    [SerializeField] bool allNumberInPlace = false;
    [SerializeField] bool popupText = false;
    [SerializeField] bool loadNextLvl = false;

    private SaveLoadFile slf;
    private bool finished = false;

    private void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count == totalNumber)
        {
            allNumberInPlace = true;

            //save current scene
            if (nextLevel != "" && nextLevel != "TopicsNumberScene")
            {
                slf.SaveCurrentSceneTrainStation(nextLevel);
            }
            else
            {
                slf.ResetGameTrainStation();

                if (!slf.CheckCompleteGame("GameTrainStation"))
                {
                    //increase key
                    slf.IncreaseKey();

                    //complete game
                    slf.CompleteGame("GameTrainStation");

                    this.finished = true;
                }
            }
        }
        if (popupText)
        {
            //popup.SetActive(true);
            StartCoroutine(ShowPopUp());
        }

        if (loadNextLvl)
        {
            if(nextLevel != "TopicsNumberScene")
            {
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                StartCoroutine(ShowPopUp());

                //win game
                StartCoroutine(WinGame());
            }
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

    IEnumerator ShowPopUp()
    {
        yield return new WaitForSeconds(0.5f);
        if(popUpCanvas != null)
        {
            popUpCanvas.SetActive(true);
        }
        
        yield return new WaitForSeconds(2f);
        Destroy(popUpCanvas);
        train.MoveToNextWayPoint(true);
    }
    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(3f);
        
        gameWinCanvas.SetActive(true);
        yield return new WaitForSeconds(timeTransition);
        //countUI.SetActive(false);

        Debug.Log(finished && getKeyRewardCanvas != null);
        if (finished && getKeyRewardCanvas != null)
        {
            gameWinCanvas.GetComponentInChildren<Animator>().SetTrigger("Disappear");
            getKeyRewardCanvas.SetActive(true);
            yield return new WaitForSeconds(timeTransition);
        }

        SceneManager.LoadScene("TopicsNumberScene");
    }
}
