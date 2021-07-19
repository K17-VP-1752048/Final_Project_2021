using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class HandleNumber : MonoBehaviour
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
