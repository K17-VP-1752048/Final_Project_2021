using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        text.color = new Color32(255, 246, 0, 255);
        audioSource.Play();
    }
}