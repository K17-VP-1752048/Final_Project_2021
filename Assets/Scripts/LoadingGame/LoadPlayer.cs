using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadPlayer : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private string nameGame;

    private SaveLoadFile slf;

    private void Start()
    {
        //StartCoroutine(LoadAsynchronously(PlayerPrefs.GetString(namePlayerPrefs, valueDefault)));
        slf = gameObject.AddComponent<SaveLoadFile>();

        if (nameGame == "GameMatch")
        {
            string nameScene = slf.LoadCurrentSceneMatch();
            if(nameScene == null)
            {
                StartCoroutine(LoadAsynchronously("Animals_Match1"));
            }
            else
            {
                //back topic animal in UpLevelScript
                StartCoroutine(LoadAsynchronously(nameScene));
            }
        }
        else if (nameGame == "GameCountNumber")
        {
            string nameScene = slf.LoadCurrentSceneCountNumber();
            if (nameScene == null)
            {
                StartCoroutine(LoadAsynchronously("Number_Count1"));
            }
            else
            {
                //back topic animal in UpLevelScript
                StartCoroutine(LoadAsynchronously(nameScene));
            }
        }
        else if (nameGame == "GameFindFood")
        {
            string nameScene = slf.LoadCurrentSceneFindFood();
            if (nameScene == null)
            {
                StartCoroutine(LoadAsynchronously("Aliment_Find1"));
            }
            else
            {
                //back topic animal in UpLevelScript
                StartCoroutine(LoadAsynchronously(nameScene));
            }
        }
        else if (nameGame == "GamePickToRoom")
        {
            string nameScene = slf.LoadCurrentScenePickToRoom();
            if (nameScene == null)
            {
                StartCoroutine(LoadAsynchronously("PickObjectToRoom1"));
            }
            else
            {
                //back topic animal in UpLevelScript
                StartCoroutine(LoadAsynchronously(nameScene));
            }
        }
    }

    IEnumerator LoadAsynchronously(string nameScene)
    {
        yield return new WaitForSeconds(0.5f);
        progressBar.fillAmount = 0.5f;
        yield return new WaitForSeconds(0.5f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
        while (!operation.isDone)
        {
            //progressBar.fillAmount = operation.progress;
            progressBar.fillAmount = 1;

            yield return null;
        }
    }
}
