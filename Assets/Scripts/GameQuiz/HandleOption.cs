using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

[RequireComponent(typeof(BoxCollider2D))]
public class HandleOption : MonoBehaviour
{
    public UnityEvent downEvent;
    void OnMouseDown()
    {
        //run event
        downEvent?.Invoke();
    }
}
