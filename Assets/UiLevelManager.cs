using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiLevelManager : MonoBehaviour
{
    [SerializeField] GameObject levelBtnPrefab;
    [SerializeField] int numberOfLevels = 8;
    [SerializeField] int numberOfLevelsUnlocked = 3;
    [SerializeField] Color color;

    // Start is called before the first frame update
    void Start()
    {
        GameObject levelBtn;
        for(int i = 0; i < numberOfLevels; i++)
        {
            levelBtn = Instantiate(levelBtnPrefab, transform);
            if(i < numberOfLevelsUnlocked)
            {
                levelBtn.transform.GetComponentInChildren<TMP_Text>().text = "" + (i + 1);
                levelBtn.transform.GetComponent<Image>().color = color;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
