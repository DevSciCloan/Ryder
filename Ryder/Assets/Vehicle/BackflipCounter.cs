using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackflipCounter : MonoBehaviour
{
     private bool inAir;
    private int flipCount;
    private float currentRotation;
    private float prevRotation;
    private Rigidbody2D rb;
    private TrackMagnetism trackMagnetism;
    public UnityEvent<int> flipCountUpdate;
    [SerializeField] PlayerPointsScriptableObject playerPoints;
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
        
        CountBackflips();
        
    }

    // Counts backflips based on rigidbody2d rotation
    private void CountBackflips()
    {
        if (inAir)
        {
            if (rb.rotation > prevRotation)
            {
                currentRotation += rb.rotation - prevRotation;
                prevRotation = rb.rotation;
            }
            // This if statement would reset the currentRotation if the player rotates clockwise. 
            // Currently commented out because the player sometimes rotates clockwise briefly and a backflip doesn't get counted
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

    // Called when player lands by invoking an event in TrackMagnetism script
    void Landed()
    {
        inAir = false;
        currentRotation = 0;
        // TODO Update player score total
        playerPoints.PlayerPoints += flipCount;
        // PlayerScoreTotal += flipCount;
        flipCount = 0;
    }

    // Called when player becomes airborne by invoking an event in TrackMagnetism script
    void LiftedOff()
    {
        currentRotation = 0;
        inAir = true;
    }
}
