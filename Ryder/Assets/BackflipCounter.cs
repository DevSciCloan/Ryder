using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackflipCounter : MonoBehaviour
{
     private bool inAir;
    private int flipCount;
    private float currentRotation;
    private float prevRotation;
    private Rigidbody2D rb;
    private TrackMagnetism trackMagnetism;
    // private float initialRotation;

    void Awake()
    {
        trackMagnetism = GetComponent<TrackMagnetism>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        trackMagnetism.OnGrounded += Landed;
        trackMagnetism.OnLeftGround += LiftedOff;
    }

    void OnDisable()
    {
        trackMagnetism.OnGrounded -= Landed;
        trackMagnetism.OnLeftGround -= LiftedOff;
    }

    void LateUpdate()
    {
        
        if (inAir)
        {
            if (rb.rotation > prevRotation)
            {
                currentRotation += rb.rotation - prevRotation;
                prevRotation = rb.rotation;
            }
            if (rb.rotation < prevRotation)
            {
                currentRotation = 0;
            }
            if (currentRotation >= 270)
            {
                currentRotation = 0;
                flipCount++;
                // TODO add UI flip count display
                // Debug.Log(flipCount);  
                
            }
        }
        else
        {
            currentRotation = 0;
        }
        
    }

    void Landed()
    {
        inAir = false;
        flipCount = 0;
        currentRotation = 0;
    }

    void LiftedOff()
    {
        currentRotation = 0;
        inAir = true;
    }
}
