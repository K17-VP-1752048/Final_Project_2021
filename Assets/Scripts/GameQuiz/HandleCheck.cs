using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class HandleCheck : MonoBehaviour
{
    [SerializeField] private Image checkImg;
    public UnityEvent upEvent;
    public UnityEvent downEvent;
    void OnMouseDown()
    {
        checkImg.color = new Color(0.5962264f, 0.745283f, 0, 1);
        checkImg.GetComponent<AudioSource>().Play();
        //run event
        downEvent?.Invoke();
    }

    private void OnMouseUp()
    {
        checkImg.color = new Color(1, 1, 1, 1);
        //run event
        upEvent?.Invoke();
    }
}
