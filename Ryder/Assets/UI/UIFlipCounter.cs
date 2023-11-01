using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIFlipCounter : MonoBehaviour
{
    private BackflipCounter bfCounter;
    private TrackMagnetism trackMagnetism;
    private TMP_Text counterText;
    Animator animator;
    

    void Awake()
    {
        counterText = GetComponent<TMP_Text>();
        animator = GetComponent<Animator>();
        GameObject carBody = GameObject.Find("Hoverboard");
        bfCounter = carBody.GetComponent<BackflipCounter>();
        trackMagnetism = carBody.GetComponent<TrackMagnetism>();
    }

    void OnEnable()
    {
        bfCounter.flipCountUpdate.AddListener( UpdateCounter);
        trackMagnetism.OnGrounded += Landed;
        trackMagnetism.OnLeftGround += LiftedOff;
    }

    void OnDisable()
    {
        bfCounter.flipCountUpdate.RemoveListener(UpdateCounter);
        trackMagnetism.OnGrounded -= Landed;
        trackMagnetism.OnLeftGround -= LiftedOff;
    }

    void UpdateCounter(int flipCount)
    {
        counterText.text = "+"+flipCount.ToString();

        if (flipCount > 0)
        {
            animator.SetTrigger("Go");
        }
        
    }

    void LiftedOff()
    {
        counterText.text = "+0";
        animator.SetBool("InAir", true);
        animator.SetBool("Landed", false);
    }

    void Landed()
    {
        animator.SetBool("InAir", false);
        animator.SetBool("Landed", true);
    }
}
