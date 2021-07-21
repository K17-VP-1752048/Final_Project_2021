using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPlaySound : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (KeepSoundPlay.state)
        {
            AudioSource audioSource = animator.gameObject.GetComponent<AudioSource>();
            audioSource.PlayDelayed(stateInfo.normalizedTime / 2);
        }
    }

}
