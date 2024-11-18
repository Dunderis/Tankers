using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthPrefab;
    public float spawnRate = 5.0f;

    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, spawnRate);
    }

    void Spawn()
    {
        Instantiate(healthPrefab, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
    }
}
