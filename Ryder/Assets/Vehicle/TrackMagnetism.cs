
using System;
using UnityEngine;
using UnityEngine.Events;

public class TrackMagnetism : MonoBehaviour
{
    [SerializeField] WheelGrounded fWheelGrounded;
    private Rigidbody2D frontWheel;
    [SerializeField] WheelGrounded bWheelGrounded;
    private Rigidbody2D backWheel;
    [SerializeField] float magnetStrength;
    [SerializeField] float backflipSpeed;
    [SerializeField] float maxBackflipSpeed;
    [SerializeField] float frontflipSpeed;
    Rigidbody2D vehicleBody;
    private bool shouldInvokeNextGrounded = true;
    private bool shouldInvokeNextLeftGround;
    bool touchedDown;
    public bool TouchedDown {get{return touchedDown;}}

    public UnityEvent OnGrounded;
    public UnityEvent OnLeftGround;

    private bool spaceHeld;
    void Awake()
    {
        vehicleBody = GetComponent<Rigidbody2D>();
        frontWheel = fWheelGrounded.gameObject.GetComponent<Rigidbody2D>();
        backWheel = bWheelGrounded.gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        // Pushes player into the track to allow vertical traversing of obstacles
        if (fWheelGrounded.Grounded && bWheelGrounded.Grounded)
        {
            if (!touchedDown) touchedDown = true;
            // Vector3 betweenWheelsVector = fWheelGrounded.gameObject.transform.position - bWheelGrounded.gameObject.transform.position;
            vehicleBody.AddForce(-transform.up * magnetStrength, ForceMode2D.Force);
        }
        // Slight clockwise rotation applied here while not holding spacebar
        else if ((!fWheelGrounded.Grounded && !bWheelGrounded.Grounded) && !spaceHeld)
        {
            if (vehicleBody.angularVelocity > 0)
            {
                vehicleBody.angularVelocity = 0;
            }
            vehicleBody.AddTorque(-frontflipSpeed);
        }
        // Prevents backflip on scene start until vehicle has become grounded. 
        // After initial grounding anytime the player is not grounded and spacebar is held apply counter clockwise rotation
        else if ((!fWheelGrounded.Grounded && !bWheelGrounded.Grounded) && spaceHeld && touchedDown)
        {
            // Makes the transition from clockwise to counter clockwise instant
            if (vehicleBody.angularVelocity < 0)
            {
                vehicleBody.angularVelocity = 0;
            }
            // Limits counter clockwise rotation speed
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
        spaceHeld = Input.GetKey(KeyCode.Space); // Can be replaced by accessing MotorSpeed.OnSpacebarPressedValueChange
    }

    void LateUpdate()
    {
        HandleGroundedEvents();
    }

    // Handles invoking grounded and airborne events
    private void HandleGroundedEvents()
    {
        if (shouldInvokeNextGrounded && fWheelGrounded.Grounded && bWheelGrounded.Grounded)
        {
            shouldInvokeNextGrounded = false;
            shouldInvokeNextLeftGround = true;
            OnGrounded?.Invoke();
        }
        if (shouldInvokeNextLeftGround && !shouldInvokeNextGrounded && !fWheelGrounded.Grounded && !bWheelGrounded.Grounded)
        {
            shouldInvokeNextLeftGround = false;
            shouldInvokeNextGrounded = true;
            OnLeftGround?.Invoke();
        }
    }
}
