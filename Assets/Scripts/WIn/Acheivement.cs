using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acheivement : MonoBehaviour
{
    [SerializeField] float timeWait = 2f;
    [SerializeField] List<Sprite> acheivementSprites;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return new WaitForSeconds(timeWait);
            animator.SetTrigger("FadeOut");
        }
    }

    
}
