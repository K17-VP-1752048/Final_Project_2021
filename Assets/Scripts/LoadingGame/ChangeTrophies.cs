using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrophies : MonoBehaviour
{
    [SerializeField] GameObject bronze, champion, hero;

    private SaveLoadFile slf;
    private int box;
    // Start is called before the first frame update
    void Start()
    {
        //initiate
        slf = gameObject.AddComponent<SaveLoadFile>();

        box = slf.LoadBox();
        if (box > 2 && box < 6)
        {
            bronze.gameObject.SetActive(false);
            champion.gameObject.SetActive(true);
        }
        else if (box >= 6)
        {
            bronze.gameObject.SetActive(false);
            hero.gameObject.SetActive(true);
        }
    }

    /* // Update is called once per frame
     void Update()
     {
         box = slf.LoadBox();
         if (box > 2 && box < 6)
         {
             bronze.gameObject.SetActive(false);
             champion.gameObject.SetActive(true);
         }
         else if (box >= 6)
         {
             bronze.gameObject.SetActive(false);
             hero.gameObject.SetActive(true);
         }
     }*/
}
