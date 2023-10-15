using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] float boostSpeed;
    [SerializeField] float boostDuration;
    [SerializeField] WheelJoint2D backWheel;
    private bool slowDown;
    Coroutine speedBoost;
    private float startSpeed;
    [SerializeField] float slowDownSpeed;
   
    void Awake()
    {
        startSpeed = backWheel.motor.motorSpeed;
    }

    void FixedUpdate()
    {
        if (slowDown)
        {
            JointMotor2D motor = backWheel.motor;
            motor.motorSpeed = Mathf.MoveTowards(motor.motorSpeed, startSpeed, slowDownSpeed * Time.deltaTime);
            backWheel.motor = motor;
            if (motor.motorSpeed <= startSpeed)
            {
                motor.motorSpeed = startSpeed;
                backWheel.motor = motor;
                slowDown = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Body")
        {
            //.AddForce(boostSpeed * other.transform.right,ForceMode2D.Impulse);
            JointMotor2D motor = backWheel.motor;
            motor.motorSpeed += boostSpeed;
            backWheel.motor = motor;
            speedBoost = StartCoroutine(HandleBoost());
        }
    }

    IEnumerator HandleBoost()
    {
        yield return new WaitForSecondsRealtime(boostDuration);
        slowDown = true;
    }
}
