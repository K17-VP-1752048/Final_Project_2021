using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NormalObject : MonoBehaviour, IPointerDownHandler
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        audioSource.Play();
    }
}
