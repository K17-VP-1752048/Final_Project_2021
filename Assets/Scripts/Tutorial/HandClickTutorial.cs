using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandClickTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial()
    {
        gameObject.GetComponent<Animator>().SetTrigger("SingleClick");

        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
