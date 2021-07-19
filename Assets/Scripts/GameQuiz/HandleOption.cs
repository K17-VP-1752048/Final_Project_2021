using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

[RequireComponent(typeof(BoxCollider2D))]
public class HandleOption : MonoBehaviour
{
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
            //run event
            downEvent?.Invoke();
        }
    }
}
