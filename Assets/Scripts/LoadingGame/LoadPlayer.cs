using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadPlayer : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private string nameGame;
    private AudioSource bgMusic;

    private SaveLoadFile slf;

    private void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
        bgMusic = GameObject.Find("BackgroundAudio").GetComponent<AudioSource>();
        bgMusic.mute = true;

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
        else if (nameGame == "GameLigature")
        {
            string nameScene = slf.LoadCurrentSceneLingature();
            if (nameScene == null)
            {
                StartCoroutine(LoadAsynchronously("Lingature1"));
            }
            else
            {
                //back topic animal in UpLevelScript
                StartCoroutine(LoadAsynchronously(nameScene));
            }
        }
        else if (nameGame == "GameTrainStation")
        {
            string nameScene = slf.LoadCurrentSceneTrainStation();
            if (nameScene == null)
            {
                StartCoroutine(LoadAsynchronously("TrainStation1"));
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
        yield return new WaitForSeconds(.5f);
        progressBar.fillAmount = 0.2f;
        yield return new WaitForSeconds(.5f);
        progressBar.fillAmount = 0.4f;
        yield return new WaitForSeconds(.5f);
        progressBar.fillAmount = 0.6f;
        yield return new WaitForSeconds(.5f);
        progressBar.fillAmount = 0.9f;
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
        while (!operation.isDone)
        {
            //progressBar.fillAmount = operation.progress;
            progressBar.fillAmount = 1;
            bgMusic.mute = false;

            yield return null;
        }
    }
}
