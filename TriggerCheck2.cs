using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck2 : MonoBehaviour
{
    public Parking Parking;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCar"))
        {
            Parking.isCollideWithTarget2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        Parking.isCollideWithTarget2 = false;
    }

}
