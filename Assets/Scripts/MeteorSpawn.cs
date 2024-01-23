using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float minimumSpawnDelay = 1f;
    public float maximumSpawnDelay = 3f;
    public float spawnAxisXLimit = 6f;

    private void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        // Метеор создается в случайной позиции по оси X
        float random = Random.Range(-spawnAxisXLimit, spawnAxisXLimit);
        Vector3 spawnPosition = transform.position + new Vector3(random, 0f, 0f);
        Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

        Invoke("Spawn", Random.RandomRange(minimumSpawnDelay, maximumSpawnDelay));
    }
}
