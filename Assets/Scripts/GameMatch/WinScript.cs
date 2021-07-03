using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScript : MonoBehaviour
{
    [SerializeField] private GameObject myAnimals;
    [SerializeField] private string nextScene = "";
    [SerializeField] private GameObject[] congrats;
    [SerializeField] private AudioClip bravo_audio;

    [SerializeField] private GameObject gameWinCanvas;
    [SerializeField] private GameObject getKeyRewardCanvas;

    private int pointsToWin;
    private int currentPoints;
    private SaveLoadFile slf;
    private bool setActive = true;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        //initiate
        slf = gameObject.AddComponent<SaveLoadFile>();

        pointsToWin = myAnimals.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            if (setActive)
            {
                //save next scene after win
                if (nextScene != "TopicsAnimalsScene" && nextScene != "")
                {
                    setActive = false;

                    //PlayerPrefs.SetString("nextSceneMatch", nextScene);
                    slf.SaveCurrentSceneMatch(nextScene);

                    //Next scene
                    StartCoroutine(PrintfAfter(2.5f));
                }
                else
                {
                    setActive = false;

                    //Win game
                    slf.ResetGameMatch();

                    if (!slf.CheckCompleteGame("GameMatch"))
                    {
                        slf.IncreaseKey();
                        slf.CompleteGame("GameMatch");
                        this.finished = true;
                    }

                    StartCoroutine(WinGame(4f));
                }
            }
        }
    }

    IEnumerator PrintfAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        //random popup congratulation
        int val = Random.Range(0, congrats.Length);
        transform.GetChild(0).GetChild(val).gameObject.SetActive(true);

        //setting audio
        transform.GetComponent<AudioSource>().clip = bravo_audio;
        transform.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(transform.GetComponent<AudioSource>().clip.length + 0.2f);
        setActive = true;
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator WinGame(float seconds)
    {
        gameWinCanvas.SetActive(true);
        yield return new WaitForSeconds(seconds);

        if (finished && getKeyRewardCanvas != null)
        {
            if (getKeyRewardCanvas != null)
            {
                gameWinCanvas.GetComponentInChildren<Animator>().SetTrigger("Disappear");
                getKeyRewardCanvas.SetActive(true);
                yield return new WaitForSeconds(2f);
            }
        }
        
        SceneManager.LoadScene("TopicsAnimalsScene");
        setActive = true;
    }

    public void AddPoints()
    {
        this.currentPoints++;
    }
}
