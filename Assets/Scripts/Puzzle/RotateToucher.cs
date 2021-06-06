using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToucher : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(!PuzzleControl.win)
        {
            transform.Rotate(0f, 0f, 90f);
            PuzzleControl.CheckAnswer();
        }
    }
}
