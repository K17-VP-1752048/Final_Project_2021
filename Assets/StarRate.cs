using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarRate : MonoBehaviour
{
    private Image progressBar;
    private GameObject stars;
    // Start is called before the first frame update
    void Start()
    {
        progressBar = transform.GetChild(0).Find("Fill").GetComponent<Image>();
        stars = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(UpdateProgressBar());
    }

    public void UpdateStarRate(int starAchieved)
    {
        float fillAmmount = 0;
        if(starAchieved == 1)
        {
            fillAmmount = 0.25f;
        }
        if(starAchieved == 2)
        {
            fillAmmount = 0.6f;
        }
        if(starAchieved >= 3)
        {
            fillAmmount = 1f;
        }
        progressBar.fillAmount = fillAmmount;
        for(int i = 0; i < starAchieved; i++)
        {
            stars.transform.GetChild(i).GetComponent<Animator>().SetTrigger("Unlocked");
        }
    }

    
}
