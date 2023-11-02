
using TMPro;
using UnityEngine;

public class UIFlipCounter : MonoBehaviour
{
    [SerializeField] BackflipCounter bfCounter;
    private TrackMagnetism trackMagnetism;
    private TMP_Text counterText;
    [SerializeField] Animator _animator;
    

    void Awake()
    {
        counterText = GetComponent<TMP_Text>();
        // _hasAnimator = TryGetComponent<Animator>(out _animator);
        // _animator = GetComponent<Animator>();
        GameObject carBody = GameObject.Find("Hoverboard");
        // bfCounter = carBody.GetComponent<BackflipCounter>();
        trackMagnetism = carBody.GetComponent<TrackMagnetism>();
        // Debug.Log("Finished UIFlipCounter awake");
    }

    void OnEnable()
    {
        bfCounter.flipCountUpdate.AddListener(UpdateCounter);
        trackMagnetism.OnGrounded.AddListener(Landed);
        trackMagnetism.OnLeftGround.AddListener(LiftedOff);
    }

    void OnDisable()
    {
        bfCounter.flipCountUpdate.RemoveListener(UpdateCounter);
        trackMagnetism.OnGrounded.RemoveListener(Landed);
        trackMagnetism.OnLeftGround.RemoveListener(LiftedOff);
    }

    void UpdateCounter(int flipCount)
    {
        counterText.text = "+"+flipCount.ToString();

        if (flipCount > 0)
        {
            _animator.SetTrigger("Go");
        }
        
    }

    void LiftedOff()
    {
        counterText.text = "+0";
        _animator.SetBool("InAir", true);
        _animator.SetBool("Landed", false);
    }

    void Landed()
    {
        _animator.SetBool("InAir", false);
        _animator.SetBool("Landed", true);
    }
}
