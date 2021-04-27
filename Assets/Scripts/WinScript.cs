using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void AddPoints()
    {
        this.currentPoints++;
    }
}
