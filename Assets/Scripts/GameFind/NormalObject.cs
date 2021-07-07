using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NormalObject : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameFindSentinel sentinel = null; // can be ignore if it's not the first scene

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (sentinel == null)
        {
            audioSource.Play();
        }
        else if (sentinel != null)
        {
            if (!sentinel.GetHandGuideState())
            {
                audioSource.Play();
            }
        }
    }
}
