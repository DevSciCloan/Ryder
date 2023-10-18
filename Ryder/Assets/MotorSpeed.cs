using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSpeed : MonoBehaviour
{
    [SerializeField] WheelJoint2D backWheel;
    JointMotor2D motor;
    [SerializeField] WheelGrounded bWheelGrounded;
    private bool spacebarPressed;
    public bool OnSpacebarPressedValueChange
    {
        get{return spacebarPressed;}
        set{
            spacebarPressed = value;
            
            UseMotor(value);
        }
    }
    
    void Awake()
    {
        motor = backWheel.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacebarPressedValueChange = true;
            
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            OnSpacebarPressedValueChange = false;
        }
    }

    private void UseMotor(bool value)
    {
        backWheel.useMotor = value;
    }
}
