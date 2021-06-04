using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyReward : MonoBehaviour
{
    [SerializeField] float timeDelay = 1f;
    [SerializeField] GameObject sunShinesFX;

    private Animator keyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        keyAnimator = transform.GetChild(1).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LoadAnimations());
        StartCoroutine(ShowSunShinesFX(keyAnimator));
    }

    IEnumerator LoadAnimations()
    {
        for(int i = 0; i < 2; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(timeDelay);
        }
    }

    IEnumerator ShowSunShinesFX(Animator animator)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RotateUp"))
        {
            yield return new WaitForSeconds(timeDelay);
            GameObject key = transform.GetChild(1).gameObject;

            sunShinesFX.transform.position = key.transform.position;
            sunShinesFX.SetActive(true);
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
