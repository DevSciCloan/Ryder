using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] float boostSpeed;
    [SerializeField] float boostDuration;
    [SerializeField] WheelJoint2D backWheel;
    private bool slowDown;
    Coroutine speedBoost; // Can be used to StopCoroutine(speedBoost) if needed
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
        EaseMotorSpeedBackToNormalSpeed();
    }

    // You need to take a JointMotor2D, assign motorSpeed, and then assign the JointMotor2D to the WheelJoint2D.motor in order to adjust motorSpeed at runtime
    private void EaseMotorSpeedBackToNormalSpeed()
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
                // Helps ensure that speed boosts effect the player speed
                // Must set useMotor after assigning new JointMotor2D
                if (!backWheel.gameObject.GetComponent<MotorSpeed>().OnSpacebarPressedValueChange)
                {
                    // Debug.Log("use motor false");
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
            // Helps ensure that speed boosts effect the player speed
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
