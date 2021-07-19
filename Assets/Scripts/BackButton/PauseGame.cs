using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject blocker;
    private bool isPause = false;

    public void Pause()
    {
        Time.timeScale = 0f;
        blocker.SetActive(true);
        isPause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        StartCoroutine("ResumeDelay");
        blocker.SetActive(false);
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
