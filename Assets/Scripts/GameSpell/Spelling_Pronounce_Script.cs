using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class Spelling_Pronounce_Script : MonoBehaviour
{
    [SerializeField] private Image pronounceImg;
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
            pronounceImg.color = new Color(0.5962264f, 0.745283f, 0, 1);
            //run event
            downEvent?.Invoke();
        }
    }

    private void OnMouseUp()
    {
        if (!pause.IsPause())
        {
            pronounceImg.color = new Color(1, 1, 1, 1);
            //run event
            upEvent?.Invoke();
        }
    }
}
