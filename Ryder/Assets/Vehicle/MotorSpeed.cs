using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSpeed : MonoBehaviour
{
    [SerializeField] WheelJoint2D backWheel;
    JointMotor2D motor;
    // [SerializeField] WheelGrounded bWheelGrounded;
    private bool spacebarPressed;
    public bool OnSpacebarPressedValueChange
    {
        get{return spacebarPressed;}
        set{
            spacebarPressed = value;
            
            UseMotor(value); // Call this function when OnSpacebarPressedValueChange value changes
        }
    }
    
    void Awake()
    {
        motor = backWheel.motor;
    }

    // Update is called once per frame
    void Update()
    {
        DetectSpacebarHeld();
    }

    // Toggles spacebarPressed bool when Spacebar is pressed or released
    private void DetectSpacebarHeld()
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
    // Sets useMotor to bool value
    private void UseMotor(bool value)
    {
        backWheel.useMotor = value;
    }
}
