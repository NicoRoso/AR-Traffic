using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject[] _cars;
    public GameObject _waypoint;
    public GameObject _endPoint;

    [SerializeField]
    Transform _spawnPosition;

    [SerializeField]
    private float spawnInterval = 5f;

    bool isCanSpawn = false;

    private void Start()
    {
        StartCoroutine(SpawnCarsRoutine());
    }

    public void SpawnCars()
    {
        var random = Random.Range(0, _cars.Length);

        GameObject newCar = Instantiate(_cars[random], _spawnPosition.position, transform.rotation);

        newCar.transform.SetParent(transform);

    }

    public void SpawnWaypoint() => Instantiate(_waypoint, transform);
    public void SpawnEndpoint() => Instantiate(_endPoint, transform);


    public void StartSpawn()
    {
        isCanSpawn = !isCanSpawn;
    }

    private IEnumerator SpawnCarsRoutine()
    {
        while (true)
        {
            if (isCanSpawn)
            {
                SpawnCars();
                yield return new WaitForSeconds(spawnInterval);
            }
            yield return null;
        }
    }
}
