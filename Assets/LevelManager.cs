using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int correctAns = 0;
    [SerializeField] StarRate starRateBar;
    [SerializeField] DataAnimalsScriptable dataNumber;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckAnswer()
    {
        correctAns++;
        starRateBar.UpdateStarRate(correctAns);
        
    }

    public void CreateCardData()
    {

    }
}
