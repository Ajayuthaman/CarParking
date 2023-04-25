using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public Parking Parking;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCar"))
        {
            Parking.isCollideWithTarget = true;            
        }
    }
    private void OnTriggerExit(Collider other)
    {

        Parking.isCollideWithTarget = false;
    }
}
