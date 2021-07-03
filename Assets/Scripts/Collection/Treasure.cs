using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : MonoBehaviour
{
    private string puzzleName;
    [SerializeField] TreasureManager treasureManager;
    [SerializeField] int keyNeed;

    public void openATreasure()
    {
        puzzleName = this.transform.parent.name;
        Debug.Log("Click on button " + puzzleName);

        // check if treasure is in the middle of screen
        // ...

        if (GetComponent<Image>().color == Color.white)
        {
            // check the keys
            if (treasureManager.checkTreasureKey(keyNeed))
            {
                treasureManager.startOpenTreasureAnim(puzzleName, keyNeed);
            }
            else
            {
                // Alert that keys are not enough
                treasureManager.alertNotEnoughKey(showMessageOfTreasure());
            }
        }
        else
        {
            treasureManager.alertTreasureCanNotOpen();
        }
    }

    public string showMessageOfTreasure()
    {
        if(keyNeed < 2)
            return "Trouver " + keyNeed + " clé pour ouvrir ce trésor";
        else
            return "Trouver " + keyNeed + " clés pour ouvrir ce trésor";
    }
}
