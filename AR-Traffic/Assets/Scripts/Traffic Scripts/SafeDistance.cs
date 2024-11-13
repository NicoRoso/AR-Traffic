using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SafeDistance : MonoBehaviour
{
    [SerializeField]
    private CarAI carAI;

    [SerializeField]
    private float detectionDistance;
    [SerializeField]
    private string carTag = "Car";

    public bool isThisCar;


    private void Start()
    {
        carAI = GetComponent<CarAI>();
        detectionDistance = Random.Range(5, 10);
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        Ray ray = new Ray(transform.position, forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, detectionDistance) && hit.collider.CompareTag(carTag))
        {
            isThisCar = true;
        }
        else
        {
            isThisCar = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * detectionDistance);
    }
}