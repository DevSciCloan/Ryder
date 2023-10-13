using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSpeed : MonoBehaviour
{
    [SerializeField] WheelJoint2D backWheel;
    JointMotor2D motor;
    [SerializeField] WheelGrounded bWheelGrounded;
    
    void Awake()
    {
        motor = backWheel.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && bWheelGrounded.Grounded)
        {
            backWheel.useMotor = true;
            
        }
        else
        {
            
            backWheel.useMotor = false;
        }

    }
}
