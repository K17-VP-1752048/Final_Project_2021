using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] List<RectTransform> wayPoints;
    [SerializeField] int moveSpeed = 400;
    [SerializeField] WheelJoint2D backWheel;
    //[SerializeField] WheelJoint2D frontWheel;

    private int wayPointIndex = 0;
    private bool moving = true;
    private TrainStationLevel level;
    private bool moveToNextWP = false;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<TrainStationLevel>().GetComponent<TrainStationLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPointIndex <= wayPoints.Count - 1 && moving)
        {
            var targetPosition = wayPoints[wayPointIndex].position;
            Move();
            if (Vector2.Distance(transform.position, targetPosition) < 2f)
            {
                Debug.Log("Stop");
                Stop();  
            }
        }
        if (level.AllNumberIsInPlace())
        {
            level.TogglePopupText(true);
        }
        if (moveToNextWP)
        {
            wayPointIndex = 1;
            moving = true;
        }
        if (Vector2.Distance(transform.position, wayPoints[wayPoints.Count - 1].position) < 2f)
        {
            level.LoadNextLevel(true);
        }
    }

    private void Stop()
    {
        JointMotor2D motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = 10000 };
        backWheel.motor = motor;
        //frontWheel.motor = motor;
        moving = false;
    }

    private void Move()
    {
        JointMotor2D motor = new JointMotor2D { motorSpeed = moveSpeed * -1, maxMotorTorque = 10000 };
        backWheel.motor = motor;
        //frontWheel.motor = motor;
    }

    IEnumerator WaitBeforeMoving()
    {
        yield return new WaitForSeconds(1);
        wayPointIndex++;
        moving = true;
    }

    public void MoveToNextWayPoint(bool setter)
    {
        moveToNextWP = setter;
    }
}
