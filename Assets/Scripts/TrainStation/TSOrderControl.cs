using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSOrderControl : MonoBehaviour
{
    [SerializeField] int currentOrder = 1;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextNumber()
    {
        currentOrder++;
    }

    public int CurrentOrder()
    {
        return currentOrder;
    }
}
