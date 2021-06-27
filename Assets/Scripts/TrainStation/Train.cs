using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] List<RectTransform> wayPoints;
    [SerializeField] int moveSpeed = 400;
    [SerializeField] WheelJoint2D backWheel;
    [SerializeField] AudioClip clarksonSound;
    [SerializeField] float clarksonVol = .5f;

    private int wayPointIndex = 0;
    private bool moving = true;
    private TrainStationLevel level;
    private bool moveToNextWP = false;
    private AudioSource audioSource;
    private int playRunSound = 0;
    private int playClarkson = 0;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<TrainStationLevel>().GetComponent<TrainStationLevel>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("PlayClarkson");
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
            playClarkson++;
            moving = true;
        }
        if (Vector2.Distance(transform.position, wayPoints[wayPoints.Count - 1].position) < 2f)
        {
            level.LoadNextLevel(true);
        }
        if (playRunSound == 1)
        {
            audioSource.Play();
        }
        if (playClarkson == 1)
        {
            audioSource.PlayOneShot(clarksonSound, clarksonVol);
        }
    }

    private void Stop()
    {
        JointMotor2D motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = 10000 };
        backWheel.motor = motor;
        moving = false;
        audioSource.Stop();
        audioSource.PlayOneShot(clarksonSound, clarksonVol);
        playRunSound = 0;
    }

    IEnumerator PlayClarkson()
    {
        audioSource.PlayOneShot(clarksonSound, clarksonVol);
        yield return new WaitForSeconds(clarksonSound.length + .5f);
        audioSource.PlayOneShot(clarksonSound, clarksonVol);
    }

    private void Move()
    {
        JointMotor2D motor = new JointMotor2D { motorSpeed = moveSpeed * -1, maxMotorTorque = 10000 };
        backWheel.motor = motor;
        playRunSound++;
    }

    public void MoveToNextWayPoint(bool setter)
    {
        moveToNextWP = setter;
    }
}
