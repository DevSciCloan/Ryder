using System;
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
    public event Action<int> flipCountUpdate;
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
            // if (rb.rotation < prevRotation)
            // {
            //     currentRotation = 0;
            // }
            if (currentRotation >= 300)
            {
                currentRotation = 0;
                flipCount++;
                flipCountUpdate.Invoke(flipCount);
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
        currentRotation = 0;
        // TODO Update player score total
        // PlayerScoreTotal += flipCount;
        flipCount = 0;
    }

    void LiftedOff()
    {
        currentRotation = 0;
        inAir = true;
    }
}