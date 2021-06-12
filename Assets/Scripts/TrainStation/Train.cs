using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] List<RectTransform> wayPoints;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] WheelJoint2D backWheel;

    private int wayPointIndex = 0;
    private bool moving = true;
    private TrainStationLevel level;

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
            
            StartCoroutine("WaitBeforeMoving");
        }
    }

    private void Stop()
    {
        JointMotor2D motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = 10000 };
        backWheel.motor = motor;
        moving = false;
    }

    private void Move()
    {
        /*var movementThisFrame = moveSpeed * Time.deltaTime;
        transform.position += transform.right * movementThisFrame;*/
        JointMotor2D motor = new JointMotor2D { motorSpeed = moveSpeed, maxMotorTorque = 10000 };
        backWheel.motor = motor;
    }

    IEnumerator WaitBeforeMoving()
    {
        yield return new WaitForSeconds(1);
        wayPointIndex++;
        moving = true;
    }
}
