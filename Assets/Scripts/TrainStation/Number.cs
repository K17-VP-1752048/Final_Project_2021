using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    [SerializeField] List<RectTransform> wayPoints;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpForce = 0.2f;
    [SerializeField] GameObject railroadCar;
    [SerializeField] float moveToTrainSpeed = 2f;
    [SerializeField] int order;
    [SerializeField] GameObject groundCheck;
    [SerializeField] GameObject orderControlObj;
    [SerializeField] AudioSource wrongSound;
    [SerializeField] AudioClip clip;

    private int wayPointIndex = 0;
    private bool moving = true;
    private bool isGrounded = false;
    private bool moveToTrain = false;
    private SpriteRenderer spriteRenderer;
    private TrainStationLevel level;
    private TSOrderControl orderControl;
    private AudioSource audioSource;
    private bool isReady = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        level = FindObjectOfType<TrainStationLevel>().GetComponent<TrainStationLevel>();
        orderControl = orderControlObj.GetComponent<TSOrderControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPointIndex <= wayPoints.Count - 1 && moving)
        {
            var targetPosition = wayPoints[wayPointIndex].position;
            Move();

            if (Vector2.Distance(transform.position, targetPosition) < 1.5f)
            {
                StartCoroutine("Wait");
            }
        }
        if (moveToTrain)
        {
            Vector3 targetPos = new Vector3(railroadCar.GetComponent<RectTransform>().position.x, railroadCar.GetComponent<RectTransform>().position.y + 3, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveToTrainSpeed * Time.deltaTime);

            if (transform.position == targetPos)
            {
                Drop();
                level.Count();
            }
        }
    }

    private void Drop()
    {
        gameObject.layer = 5;
        spriteRenderer.sortingOrder = 0;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        groundCheck.SetActive(true);
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        moveToTrain = false;
    }

    private void Move()
    {
        if (isGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        else
        {
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position += transform.right * movementThisFrame;
        }
    }

    IEnumerator Wait()
    {
        moving = false;
        isReady = true;
        yield return new WaitForSeconds(2);
        wayPointIndex++;
        //moving = true;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public void SetIsGrounded(bool setter)
    {
        isGrounded = setter;
    }

    public bool IsReady()
    {
        return isReady;
    }

    private void OnMouseDown()
    {
        if (!moving && order == orderControl.CurrentOrder())
        {
            isReady = false;
        }
    }

    private void OnMouseUp()
    {
        if (!moving && order == orderControl.CurrentOrder())
        {
            gameObject.AddComponent<AudioSource>();
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(clip, 1f);
            MoveToTrain();
            orderControl.NextNumber();
        }
        else if(order != orderControl.CurrentOrder())
        {
            wrongSound.Play();
            StartCoroutine(alertWrongOrder());
        }
    }

    private void MoveToTrain()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        spriteRenderer.sortingOrder = 5;
        groundCheck.SetActive(false);
        moveToTrain = true;
    }

    IEnumerator alertWrongOrder()
    {
        railroadCar.transform.GetChild(4).gameObject.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(1f);
        railroadCar.transform.GetChild(4).gameObject.GetComponent<Image>().color = Color.white;
    }
}
