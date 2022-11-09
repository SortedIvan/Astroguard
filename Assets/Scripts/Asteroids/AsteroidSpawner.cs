using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private List<Vector3> spawnPositions;
    public GameObject asteroidPrefab;
    void Start()
    {
        spawnPositions = GetSpawnPositions();
    }

    private List<Vector3> GetSpawnPositions()
    {
        List<Vector3> spawnPositions = new List<Vector3>();
        foreach (Transform child in transform)
        {
            spawnPositions.Add(child.position);
        }
        return spawnPositions;
    }

    private Vector3 GenerateRandomAsteroidSpawnPosition()
    {
        Vector3 randomSpawnArea = spawnPositions[Random.Range(0, spawnPositions.Count)];
        float x, y;
        x = Random.Range(randomSpawnArea.x - 3, randomSpawnArea.x + 3);
        y = Random.Range(randomSpawnArea.y - 3, randomSpawnArea.y + 3);
        return new Vector3(x, y, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            asteroidPrefab.transform.position = GenerateRandomAsteroidSpawnPosition();
            Instantiate(asteroidPrefab);
        }
    }
}
