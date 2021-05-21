using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Spelling_Pronounce_Script : MonoBehaviour
{
    public UnityEvent downEvent;
    void OnMouseDown()
    {
        //run event
        downEvent?.Invoke();
    }
}
