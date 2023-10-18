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
        GameObject vehicle = GameObject.Find("CarBody");
        backWheel = vehicle.GetComponents<WheelJoint2D>()[1];
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
                backWheel.gameObject.GetComponent<VelocityLimiter>().ShouldLimitVelocity = true;
                if (!backWheel.gameObject.GetComponent<MotorSpeed>().OnSpacebarPressedValueChange)
                {
                    Debug.Log("use motor false");
                    backWheel.useMotor = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "CarBody")
        {
            backWheel.gameObject.GetComponent<VelocityLimiter>().ShouldLimitVelocity = false;
            //.AddForce(boostSpeed * other.transform.right,ForceMode2D.Impulse);
            JointMotor2D motor = backWheel.motor;
            motor.motorSpeed += boostSpeed;
            backWheel.motor = motor;
            speedBoost = StartCoroutine(HandleBoost());
            if (!backWheel.gameObject.GetComponent<MotorSpeed>().OnSpacebarPressedValueChange)
            {
                backWheel.useMotor = true;
            }
        }
    }

    IEnumerator HandleBoost()
    {
        yield return new WaitForSecondsRealtime(boostDuration);
        slowDown = true;
    }
}
