using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoad : MonoBehaviour
{
    public bool hasPriority = false;
    public GameObject _yieldSign;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {

            if (!other.CompareTag("TrafficLight"))
            {
                hasPriority = true;
            }
            else
            {
                hasPriority = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            hasPriority = false;
        }
    }
    public void SpawnAndMakeChild() => Instantiate(_yieldSign, transform);
}
