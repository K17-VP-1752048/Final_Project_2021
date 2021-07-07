using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickControl : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject text;
    [SerializeField] float moveSpeed = 500f;
    [SerializeField] GameFindSentinel sentinel = null; // can be ignore if it's not the first scene
    [SerializeField] GameObject handGuide = null; // can be ignore if it's not the first scene

    private RectTransform rectTransform;
    private RectTransform textPos;
    private Animator animator;
    private bool move = false;
    private bool move2 = false;
    private GameFindLevel level;
    private AudioSource audioSource;
    private SaveLoadFile slf;

    private void Awake()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();

        if (slf.CheckCompleteGame("GameFindFood"))
        {
            if (handGuide)
            {
                Destroy(handGuide);
            }
            if (sentinel)
            {
                sentinel.SetHandGuideState(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        rectTransform = GetComponent<RectTransform>();
        textPos = text.GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
        level = FindObjectOfType<GameFindLevel>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            StartCoroutine(WaitBeforeMinimize(.025f));
        }
        if (move2)
        {
            rectTransform.position = Vector3.MoveTowards(rectTransform.position, textPos.position, moveSpeed * Time.deltaTime);

            if (rectTransform.position == textPos.position)
            {
                move2 = false;
                text.GetComponent<ObjectText>().Play();
                level.Count();
            }
        }
    }

    IEnumerator WaitBeforeMinimize(float time)
    {
        yield return new WaitForSeconds(time);
        move = false;
        move2 = true;
        animator.SetTrigger("minimize");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (sentinel == null && textPos != null)
        {
            Move();
        }
        else if (sentinel != null && textPos != null) // display tutorial if this is the first scene
        {
            if (handGuide) // Player must click at the object pointed by HandGuide
            {
                Move();
                sentinel.SetHandGuideState(false);
                Destroy(handGuide);
            }
            else if (handGuide == null && !sentinel.GetHandGuideState())
            {
                Move();
            }
        }
    }

    private void Move()
    {
        gameObject.GetComponent<Canvas>().sortingOrder = 10;
        audioSource.Play();
        StartCoroutine(WaitBeforeMaximize());
    }

    IEnumerator WaitBeforeMaximize()
    {
        animator.SetTrigger("maximize");
        yield return new WaitForSeconds(.08f);
        move = true;
    }
}
