using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFindLevel : MonoBehaviour
{
    [SerializeField] GameObject popUp, getKeyRewardCanvas;
    [SerializeField] int currentObjectNumber = 0;
    [SerializeField] int totalObjectNumber;
    [SerializeField] string nextScene = null;
    [SerializeField] float timeWait = 1f;

    private SaveLoadFile saveLoadFile;
    private bool finished = false;
    private float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        saveLoadFile = gameObject.AddComponent<SaveLoadFile>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentObjectNumber == totalObjectNumber && nextScene != null && nextScene != "TopicsAlimentsScene")
        //{
        //    //popUp.SetActive(true);
        //    //popup.GetComponent<Achievement>().StartAnimations();
        //    //StartCoroutine("LoadNextScene");
        //    SaveCurrentScene();

        //    StartCoroutine(LoadNextScene());
        //}
        //else if (currentObjectNumber == totalObjectNumber)
        //{
        //    saveLoadFile.ResetGameFindFood();

        //    if (!saveLoadFile.CheckCompleteGame("GameFindFood"))
        //    {
        //        saveLoadFile.IncreaseKey();
        //        saveLoadFile.CompleteGame("GameFindFood");
        //        this.finished = true;
        //    }

        //    StartCoroutine(LoadPopUpAndLoadScene());
        //}
        if (currentObjectNumber == totalObjectNumber)
        {
            if(nextScene != null && nextScene != "TopicsAlimentsScene")
            {
                SaveCurrentScene();
                
            }
            else
            {
                saveLoadFile.ResetGameFindFood();

                if (!saveLoadFile.CheckCompleteGame("GameFindFood"))
                {
                    saveLoadFile.IncreaseKey();
                    saveLoadFile.CompleteGame("GameFindFood");
                    this.finished = true;
                }
            }

            StartCoroutine(LoadPopUpAndLoadScene());
        }
    }

    IEnumerator LoadPopUpAndLoadScene()
    {
        popUp.SetActive(true);
        yield return new WaitForSeconds(3f);

        if (finished && getKeyRewardCanvas != null)
        {
            popUp.GetComponentInChildren<Animator>().SetTrigger("Disappear");
            getKeyRewardCanvas.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
        SceneManager.LoadScene(nextScene);
    }

    public void Count()
    {
        currentObjectNumber++;
    }

    private void SaveCurrentScene()
    {
        saveLoadFile.SaveCurrentSceneFindFood(nextScene);
    }
}
