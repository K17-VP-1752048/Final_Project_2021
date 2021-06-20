using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private bool audioSourceStopPlaying = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

        //StartCoroutine(ZoomDelay(animator.GetCurrentAnimatorStateInfo(0).length));
    }

    IEnumerator ZoomDelay(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine("AudioSourcePlay");
    }

    IEnumerator AudioSourcePlay()
    {
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
        audioSourceStopPlaying = true;
    }

    public bool AudioIsStop()
    {
        return audioSourceStopPlaying;
    }
}
