using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStationPopupTxt : MonoBehaviour
{
    [SerializeField] float moveSpeed = 200f;
    [SerializeField] List<RectTransform> waypoints;

    private int waypointIndex = 0;
    private bool moving = true;
    private RectTransform rectTransform;
    [SerializeField] Train train;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //train = FindObjectOfType<Train>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex <= waypoints.Count - 1 && moving)
        {
            var targetPosition = waypoints[waypointIndex].position;
            rectTransform.position = Vector3.MoveTowards(rectTransform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (rectTransform.position == targetPosition)
            {
                moving = false;
                StartCoroutine("Delay");
            }
        }

        if (Vector2.Distance(transform.position, waypoints[waypoints.Count - 1].position) < 1f)
        {
            train.MoveToNextWayPoint(true);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        waypointIndex++;
        moving = true;
    }
}
