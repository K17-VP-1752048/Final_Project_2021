using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOneTime : MonoBehaviour
{
    [SerializeField] private GameObject handGuide;
    [SerializeField] private GameObject handguide_clickobj, handguide_picktoroom;
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

    //tutorial PickToRoom
    public void ClickObject()
    {
        if (!slf.CheckCompleteGame(nameGame) && (handGuide != null || handguide_clickobj != null))
        {
            StartCoroutine(Tutorial_PickToRoom(handGuide, handguide_clickobj)); //click le fauteuil
        }
    }

    public void ClickRoom()
    {
        if (!slf.CheckCompleteGame(nameGame) && (handguide_clickobj != null || handguide_picktoroom != null))
        {
            StartCoroutine(Tutorial_PickToRoom(handguide_clickobj, handguide_picktoroom)); //click le salon
        }
    }

    IEnumerator Tutorial_PickToRoom(GameObject obj1, GameObject obj2)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(obj1);
        obj2.SetActive(true);
    }
}
