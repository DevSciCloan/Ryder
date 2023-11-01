using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsConsumable : MonoBehaviour
{
    [SerializeField] PlayerPointsScriptableObject playerPoints;
    [SerializeField] ParticleSystem _particleSystem;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Hoverboard")
        {
            playerPoints.PlayerPoints += 1;
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject, .25f);
        }
    }
}
