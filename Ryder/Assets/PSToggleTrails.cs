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
        trackMagnetism.OnGrounded.AddListener(ParticleTrailsOn);
        trackMagnetism.OnLeftGround.AddListener(ParticleTrailsOff);
    }

    void OnDisable()
    {
        trackMagnetism.OnGrounded.RemoveListener(ParticleTrailsOn);
        trackMagnetism.OnLeftGround.RemoveListener(ParticleTrailsOff);
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
