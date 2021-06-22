using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratsAnimation_2 : MonoBehaviour
{
    [SerializeField] float timeDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        SetAnimationsInActive();
        AudioSource audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    private void SetAnimationsInActive()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
