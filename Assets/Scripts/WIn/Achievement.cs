using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    [SerializeField] float timeWait = 2f;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LoadAnimations());
    }

    IEnumerator LoadAnimations()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_2"))
        {
            yield return new WaitForSeconds(timeWait);
            animator.SetTrigger("FadeOut");
        }
    }
}
