using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YieldSign : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Transform parentTransform = transform.parent;

        if (other.CompareTag("Car"))
        {
            if (parentTransform != null && parentTransform.GetComponent<MainRoad>().hasPriority)
            {
                other.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            }
            else 
            {
                other.gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            }
        }
    }
}
