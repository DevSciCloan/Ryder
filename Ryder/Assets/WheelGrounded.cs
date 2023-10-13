using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelGrounded : MonoBehaviour
{
    [SerializeField] bool grounded;
    public bool Grounded {get{return grounded;}}
    void OnCollisionEnter2D(Collision2D other)
    {
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
    }
}
