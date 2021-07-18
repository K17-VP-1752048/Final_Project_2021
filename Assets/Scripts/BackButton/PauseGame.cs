using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPause = false;

    public void Pause()
    {
        Time.timeScale = 0f;
        isPause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        StartCoroutine("ResumeDelay");
    }

    IEnumerator ResumeDelay()
    {
        yield return new WaitForSeconds(.3f);
        isPause = false;
    }

    public bool IsPause()
    {
        return isPause;
    }
}
