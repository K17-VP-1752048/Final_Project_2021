using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFindFinalPopup : MonoBehaviour
{
    [SerializeField] float timeWait = 3f;
    [SerializeField] string nextScene = null;

    private bool clickable = false;
    private SaveLoadFile slf;

    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
        slf.ResetGameFindFood();
        StartCoroutine("WaitBeforeClickable");
    }

    // Update is called once per frame
    void Update()
    {
        if (clickable == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    IEnumerator WaitBeforeClickable()
    {
        yield return new WaitForSeconds(timeWait);
        clickable = true;
    }
}
