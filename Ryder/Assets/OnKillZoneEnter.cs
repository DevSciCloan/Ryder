using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKillZoneEnter : MonoBehaviour
{
    [SerializeField] FailOnCollision failOnCollision;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Hoverboard")
        {
            failOnCollision.onFail?.Invoke();
        }
    }
}
