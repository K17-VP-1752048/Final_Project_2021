using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToucher : MonoBehaviour
{
    [SerializeField] AudioSource puzzleSound;
    private void OnMouseDown()
    {
        if(PuzzleControl.continu)
        {
            transform.Rotate(0f, 0f, 90f);
            puzzleSound.Play();
            PuzzleControl.CheckAnswer();
        }
    }
}
