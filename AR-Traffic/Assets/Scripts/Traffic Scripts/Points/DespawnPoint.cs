using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Destroy(other.gameObject);
        }
    }
}
