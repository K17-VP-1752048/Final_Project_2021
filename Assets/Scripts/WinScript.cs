using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScript : MonoBehaviour
{
    [SerializeField] GameObject myAnimals;

    private int pointsToWin;
    private int currentPoints;
    // Start is called before the first frame update
    void Start()
    {
        pointsToWin = myAnimals.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            //Win
            //transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(PrintfAfter(2.0f));
        }
    }

    IEnumerator PrintfAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("WinScene");
    }

    public void AddPoints()
    {
        this.currentPoints++;
    }
}
