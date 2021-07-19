using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class Spelling_Speak_Script : MonoBehaviour
{
    [SerializeField] private Image speakImg;
    public UnityEvent upEvent;
    public UnityEvent downEvent;
    private PauseGame pause;

    private void Start()
    {
        pause = FindObjectOfType<PauseGame>();
    }

    void OnMouseDown()
    {
        if (!pause.IsPause())
        {
            speakImg.color = new Color(0.5962264f, 0.745283f, 0, 1);
            //run event
            downEvent?.Invoke();
        }
    }

    void OnMouseUp()
    {
        if (!pause.IsPause())
        {
            speakImg.color = new Color(1, 1, 1, 1);
            //run event
            upEvent?.Invoke();
        }
    }
}
