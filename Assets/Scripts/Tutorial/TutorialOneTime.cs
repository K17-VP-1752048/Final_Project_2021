using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOneTime : MonoBehaviour
{
    [SerializeField] private GameObject handGuide;
    [SerializeField] private string nameGame;

    private SaveLoadFile slf;

    // Start is called before the first frame update
    void Start()
    {
        //initiate
        slf = gameObject.AddComponent<SaveLoadFile>();
    }

    // Update is called once per frame
    void Update()
    {
        //tutorial for the first scene
        if (!slf.CheckCompleteGame(nameGame) && (handGuide != null))
        {
            handGuide.SetActive(true);
        }
    }
}
