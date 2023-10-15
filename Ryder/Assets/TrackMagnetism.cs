using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMagnetism : MonoBehaviour
{
    [SerializeField] WheelGrounded fWheelGrounded;
    [SerializeField] WheelGrounded bWheelGrounded;
    [SerializeField] float magnetStrength;
    [SerializeField] float backflipSpeed;
    [SerializeField] float maxBackflipSpeed;
    [SerializeField] float frontflipSpeed;
    Rigidbody2D vehicleBody;
    bool touchedDown;
    public bool TouchedDown {get{return touchedDown;}}

    private bool spaceHeld;
    void Awake()
    {
        vehicleBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (fWheelGrounded.Grounded && bWheelGrounded.Grounded)
        {
            if (!touchedDown) touchedDown = true;
            Vector3 betweenWheelsVector = fWheelGrounded.gameObject.transform.position - bWheelGrounded.gameObject.transform.position;
            vehicleBody.AddForce(-transform.up * magnetStrength, ForceMode2D.Force);
            
        }
        else if ((!fWheelGrounded.Grounded && !bWheelGrounded.Grounded) && !spaceHeld)
        {
            if (vehicleBody.angularVelocity > 0)
            {
                vehicleBody.angularVelocity = 0;
            }
            vehicleBody.AddTorque(-frontflipSpeed);
        }
        else if ((!fWheelGrounded.Grounded && !bWheelGrounded.Grounded) && spaceHeld && touchedDown)
        {
            if (vehicleBody.angularVelocity < 0)
            {
                vehicleBody.angularVelocity = 0;
            }
            if (vehicleBody.angularVelocity > maxBackflipSpeed)
            {
                vehicleBody.angularVelocity = maxBackflipSpeed;
            }
            else 
            {
                vehicleBody.AddTorque(backflipSpeed);
            }
        }
    }

    void Update()
    {
        spaceHeld = Input.GetKey(KeyCode.Space);
    }
}
