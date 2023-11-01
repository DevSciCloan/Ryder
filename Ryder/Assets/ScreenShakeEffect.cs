using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ScreenShakeEffect : MonoBehaviour
{
    CinemachineVirtualCamera _camera;
    [SerializeField] float effectDuration;
    [SerializeField] float amplitude;
    private float duration;
    private bool shaking;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;


    void Awake()
    {
        _camera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void StartShake()
    {
        shaking = true;
        duration = effectDuration;
    }

    void FixedUpdate()
    {
        
        if (shaking)
        {
            duration -= Time.deltaTime;
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = amplitude;
        
            if (duration <= 0)
            {
                duration = effectDuration;
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.MoveTowards(cinemachineBasicMultiChannelPerlin.m_AmplitudeGain, 0, effectDuration / Time.deltaTime);
                if (cinemachineBasicMultiChannelPerlin.m_AmplitudeGain <= 0)
                {
                    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
                    shaking = false;
                    // GameObject.Find("Top").GetComponent<EggSpawner>().PauseEggs();
                }
            }
        }
        
    }
}
