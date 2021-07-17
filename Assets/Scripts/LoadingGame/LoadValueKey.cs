using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadValueKey : MonoBehaviour
{
    [SerializeField] Image keyImg;

    private SaveLoadFile slf;

    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();

        //get value key
        keyImg.GetComponentInChildren<TMP_Text>().text = slf.LoadKey().ToString();
    }

    private void Update()
    {
        //get value key
        keyImg.GetComponentInChildren<TMP_Text>().text = slf.LoadKey().ToString();
    }
}
