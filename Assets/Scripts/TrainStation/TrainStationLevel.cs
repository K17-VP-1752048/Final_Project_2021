using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStationLevel : MonoBehaviour
{
    [SerializeField] int totalNumber;

    // for debugging
    [SerializeField] int count = 0;
    [SerializeField] bool allNumberInPlace = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == totalNumber)
        {
            allNumberInPlace = true;
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
}
