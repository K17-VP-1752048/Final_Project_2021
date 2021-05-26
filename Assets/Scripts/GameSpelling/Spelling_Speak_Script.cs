using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Spelling_Speak_Script : MonoBehaviour
{
    public UnityEvent upEvent;
    public UnityEvent downEvent;
    void OnMouseDown()
    {
        //run event
        downEvent?.Invoke();
    }

    void OnMouseUp()
    {
        //run event
        upEvent?.Invoke();
    }
}
