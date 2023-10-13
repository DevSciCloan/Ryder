using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] float boostSpeed;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("boost hit");
        if (other.gameObject.name == "Body")
        {
            Debug.Log("Boost Added");
            other.GetComponent<Rigidbody2D>().AddForce(boostSpeed * other.transform.right,ForceMode2D.Impulse);
        }
    }
}
