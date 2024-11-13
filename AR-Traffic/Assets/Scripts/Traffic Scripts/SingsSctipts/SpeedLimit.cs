using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimit : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            other.gameObject.GetComponent<CarAI>()._limitOnCar = true;
        }
    }
}
