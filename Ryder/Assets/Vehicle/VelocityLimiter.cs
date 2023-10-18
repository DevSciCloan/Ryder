using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLimiter : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float maxSpeed;
    private bool shouldLimitVelocity = true;
    public bool ShouldLimitVelocity {set{shouldLimitVelocity = value;}}
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (shouldLimitVelocity && rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
