using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScript : MonoBehaviour
{
    [SerializeField] private GameObject myAnimals;
    [SerializeField] private string nextScene = "";

    private int pointsToWin;
    private int currentPoints;
    private SaveLoadFile slf;

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
            //save next scene after win
            if (nextScene != "")
            {
                //PlayerPrefs.SetString("nextSceneMatch", nextScene);
                slf.SaveCurrentSceneMatch(nextScene);
            }
            else
            {
                slf.SaveCurrentSceneMatch("TopicsAnimalsScene");
            }

            //Win
            StartCoroutine(PrintfAfter(2.0f));
            
        }
    }

    IEnumerator PrintfAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void AddPoints()
    {
        this.currentPoints++;
    }
}
