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
    //[SerializeField] string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        saveLoadFile = gameObject.AddComponent<SaveLoadFile>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObjectNumber == totalObjectNumber && nextScene != null && nextScene != "TopicsAlimentsScene")
        {
            //popUp.SetActive(true);
            //popup.GetComponent<Achievement>().StartAnimations();
            //StartCoroutine("LoadNextScene");
            SaveCurrentScene();

            StartCoroutine(LoadNextScene());
        }
        else if(currentObjectNumber == totalObjectNumber)
        {
            saveLoadFile.ResetGameFindFood();

            if (!saveLoadFile.CheckCompleteGame("GameFindFood"))
            {
                saveLoadFile.IncreaseKey();
                saveLoadFile.CompleteGame("GameFindFood");
                this.finished = true;
            }

            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        popUp.SetActive(true);
        yield return new WaitForSeconds(4f);

        if (finished)
        {
            if (getKeyRewardCanvas != null)
            {
                popUp.SetActive(false);
                getKeyRewardCanvas.SetActive(true);
                yield return new WaitForSeconds(2f);
            }
        }

        yield return new WaitForSeconds(timeWait);
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
