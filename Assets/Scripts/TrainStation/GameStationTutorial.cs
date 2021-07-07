using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStationTutorial : MonoBehaviour
{
    [SerializeField] Number pointedNumber;

    private GameObject hand;
    private SaveLoadFile slf;

    // Start is called before the first frame update
    void Start()
    {
        hand = gameObject.transform.GetChild(0).gameObject;
        slf = gameObject.AddComponent<SaveLoadFile>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!slf.CheckCompleteGame("GameTrainStation") && pointedNumber.IsReady())
        {
            hand.SetActive(true);
        }
        else
        {
            hand.SetActive(false);
        }
    }
}
