using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMagnetism : MonoBehaviour
{
    [SerializeField] WheelGrounded fWheelGrounded;
    [SerializeField] WheelGrounded bWheelGrounded;
    [SerializeField] float magnetStrength;
    Rigidbody2D vehicleBody;

    private bool spaceHeld;
    void Awake()
    {
        vehicleBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (fWheelGrounded.Grounded && bWheelGrounded.Grounded)
        {
            Vector3 betweenWheelsVector = fWheelGrounded.gameObject.transform.position - bWheelGrounded.gameObject.transform.position;
            vehicleBody.AddForce((transform.position - (betweenWheelsVector.normalized * .5f)) * magnetStrength, ForceMode2D.Force);
            
        }

        else if ((!fWheelGrounded.Grounded || !bWheelGrounded.Grounded) && !spaceHeld)
        {
            if (vehicleBody.angularVelocity > 0)
            {
                vehicleBody.angularVelocity = 0;
            }
            vehicleBody.AddTorque(-3.5f*Time.deltaTime);
        }
        else if ((!fWheelGrounded.Grounded || !bWheelGrounded.Grounded) && spaceHeld)
        {
            if (vehicleBody.angularVelocity < 0)
            {
                vehicleBody.angularVelocity = 0;
            }
            vehicleBody.AddTorque(1);
        }
    }

    void Update()
    {
        spaceHeld = Input.GetKey(KeyCode.Space);
    }
}
