using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFlipCounter : MonoBehaviour
{
    [SerializeField] BackflipCounter bfCounter;
    [SerializeField] TrackMagnetism trackMagnetism;
    private TMP_Text counterText;
    Animator animator;

    void Awake()
    {
        counterText = GetComponent<TMP_Text>();
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        bfCounter.flipCountUpdate += UpdateCounter;
        trackMagnetism.OnGrounded += Landed;
        trackMagnetism.OnLeftGround += LiftedOff;
    }

    void OnDisable()
    {
        bfCounter.flipCountUpdate -= UpdateCounter;
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
