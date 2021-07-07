using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFindSentinel : MonoBehaviour
{
    [SerializeField] bool handGuideState;
    
    public void SetHandGuideState(bool setter)
    {
        handGuideState = setter;
    }

    public bool GetHandGuideState()
    {
        return handGuideState;
    }
}
