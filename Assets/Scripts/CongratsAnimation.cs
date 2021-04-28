using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratsAnimation : MonoBehaviour
{
    [SerializeField] private Animator prevAnimator;
    [SerializeField] private Animator curAnimator;
    [SerializeField] private string prevAnimationName;
    // Start is called before the first frame update
    void Start()
    {
        curAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (prevAnimator.GetCurrentAnimatorStateInfo(0).IsName(prevAnimationName))
        {
            curAnimator.SetTrigger("Appear");
        }
    }
}
