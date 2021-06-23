using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCompleteGame : MonoBehaviour
{
    [SerializeField] private string nameGame;

    private SaveLoadFile slf;

    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nameGame != "")
        {
            if (slf.CheckCompleteGame(nameGame))
            {
                gameObject.SetActive(true);
            }
        }
    }
}
