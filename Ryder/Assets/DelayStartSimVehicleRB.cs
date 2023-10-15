using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayStartSimVehicleRB : MonoBehaviour
{
    [SerializeField] Rigidbody2D[] vehicleParts;
    void Start()
    {
        StartCoroutine(StartSimulateVehicle());
    }

    IEnumerator StartSimulateVehicle()
    {
        yield return new WaitForSecondsRealtime(1);
        foreach (var item in vehicleParts)
        {
            item.simulated = true;
        }
    }
}
