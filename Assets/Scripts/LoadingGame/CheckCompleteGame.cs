using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCompleteGame : MonoBehaviour
{
    [SerializeField] private string nameGame;
    [SerializeField] private Image completeImg;

    private SaveLoadFile slf;

    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
        if (slf.CheckCompleteGame(nameGame))
        {
            completeImg.gameObject.SetActive(true);
        }
    }
}
