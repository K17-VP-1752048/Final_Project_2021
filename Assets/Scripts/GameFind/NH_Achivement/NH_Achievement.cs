using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NH_Achievement : MonoBehaviour
{
    [SerializeField] float timeWait = 2f;
    [SerializeField] string nextScene = null;

    private Animator animator;
    private SaveLoadFile slf;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        //save current scene
        slf = gameObject.AddComponent<SaveLoadFile>();
        if (nextScene != null)
        {
            slf.SaveCurrentSceneFindFood(nextScene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("LoadAnimations");
    }

    IEnumerator LoadAnimations()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("NH_achievement_idle"))
        {
            yield return new WaitForSeconds(timeWait);
            animator.SetTrigger("FadeOut");

            if (nextScene != null)
            {
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
                SceneManager.LoadScene(nextScene);
            }

        }
    }
}
