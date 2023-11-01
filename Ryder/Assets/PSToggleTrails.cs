using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSToggleTrails : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] TrackMagnetism trackMagnetism;
    [SerializeField] 
    ParticleSystem.TrailModule trailModule;

    void Awake()
    {
        trailModule = _particleSystem.trails;
    }

    void OnEnable()
    {
        trackMagnetism.OnGrounded += ParticleTrailsOn;
        trackMagnetism.OnLeftGround += ParticleTrailsOff;
    }

    void OnDisable()
    {
        trackMagnetism.OnGrounded -= ParticleTrailsOn;
        trackMagnetism.OnLeftGround -= ParticleTrailsOff;
    }

    void ParticleTrailsOff()
    {
        trailModule.enabled = false;
    }

    void ParticleTrailsOn()
    {
        trailModule.enabled = true;
    }
}
