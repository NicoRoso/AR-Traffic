using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    [Header("WaypointsPath")]
    [SerializeField]
    private Transform _deletepoint;
    public List<Transform> _waypoints = new List<Transform>();

    [SerializeField]
    private SpawnCar _startWaypoint;

    public NavMeshAgent _agent;

    [SerializeField]
    private SafeDistance _safeDistance;

    public bool _limitOnCar = false;

    private int random;

    private void Start()
    {
        _safeDistance = GetComponent<SafeDistance>();

        _agent = GetComponent<NavMeshAgent>();


        Transform spawnCarParent = transform.parent;

        SpawnCar _startWaypoint = spawnCarParent.GetComponent<SpawnCar>();

        FindWaypoint(_startWaypoint);
        FindDeletePoint(_startWaypoint);

        random = Random.Range(4, 6);

        _agent.speed = random;

        _agent = GetComponent<NavMeshAgent>();

        if (_waypoints.Count > 0)
        {
            _agent.SetDestination(_waypoints[0].position);
        }
        else
        {
            _agent.SetDestination(_deletepoint.position);
        }
    }

    private void FixedUpdate()
    {
        if (!_limitOnCar)
        {
            _agent.speed = random;
        }
        else
        {
            _agent.speed = 2;
        }

        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            StopOnPoint();
        }

        if ((_agent.isStopped && _waypoints.Count != 0) || (_safeDistance.isThisCar && _agent.isStopped))
        {
            _agent.isStopped = false;
            if (_waypoints.Count > 0)
            {
                _agent.SetDestination(_waypoints[0].position);
            }
            else
            {
                _agent.SetDestination(_deletepoint.position);
            }
        }

        if (_safeDistance.isThisCar)
        {
            _agent.isStopped = true;

        }
        else
        {
            _agent.isStopped = false;
        }
    }


    private void StopOnPoint()
    {
        _agent.isStopped = true;
        if (_waypoints.Count > 0)
        {
            _waypoints.RemoveAt(0);
        }
        else
        {
            _agent.isStopped = false;
            _agent.SetDestination(_deletepoint.position);
        }
    }

    private void FindWaypoint(SpawnCar startWaypoint)
    {
        foreach (PathObject pointspo in startWaypoint.GetComponentsInChildren<PathObject>())
        {
            Transform point = pointspo.transform;
            _waypoints.Add(point);
        }
    }

    private void FindDeletePoint(SpawnCar startWaypoint)
    {
        foreach (DespawnPoint despawn in startWaypoint.GetComponentsInChildren<DespawnPoint>())
        {
            Transform point = despawn.transform;
            _deletepoint = point;
        }
    }
}
