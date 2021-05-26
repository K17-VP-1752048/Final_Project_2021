using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentinel : MonoBehaviour
{
    private bool alertIssued = false;
    private bool shouldStopAlert = false;
    
    public bool AlertIssued()
    {
        return alertIssued;
    }

    public bool ShouldStopAlert()
    {
        return shouldStopAlert;
    }

    public void SetAlertIssued(bool setter)
    {
        alertIssued = setter;
    }

    public void SetShouldStopAlert(bool setter)
    {
        shouldStopAlert = setter;
    }
}
