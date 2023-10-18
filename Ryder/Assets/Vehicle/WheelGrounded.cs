using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WheelGrounded : MonoBehaviour
{
    Coroutine wheelOffGround;
    private bool corStarted;
    [SerializeField] bool grounded;
    public bool Grounded {get{return grounded;}}
    void OnCollisionEnter2D(Collision2D other)
    {
        grounded = true;
        if (corStarted)
        StopCoroutine(wheelOffGround);
        corStarted = false;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        
        wheelOffGround = StartCoroutine(WheelOffGroundDelay());
        corStarted = true;
    }

    IEnumerator WheelOffGroundDelay()
    {
        yield return new WaitForNextFrameUnit();
        grounded = false;
    }
}
