using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleVehicle : MonoBehaviour
{
    [SerializeField] float vehicleSpeed;
    [SerializeField] float magnetStrength;
    [SerializeField] float backflipSpeed;
    [SerializeField] float frontflipSpeed;
    Rigidbody2D capsuleRB;
    [SerializeField] bool grounded;

    void Awake()
    {
        capsuleRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            capsuleRB.AddForce(vehicleSpeed * transform.right, ForceMode2D.Force);
        }
        if (grounded)
        {
            capsuleRB.AddForce(magnetStrength * -transform.up, ForceMode2D.Force);
        }
        if (!grounded && Input.GetKey(KeyCode.Space))
        {
            capsuleRB.AddTorque(backflipSpeed,ForceMode2D.Force);
        }
        else if (!grounded && !Input.GetKey(KeyCode.Space))
        {
            capsuleRB.angularVelocity = frontflipSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
    }
}
