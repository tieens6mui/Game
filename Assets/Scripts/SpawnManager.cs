using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private GameObject enemyPrefab;

    private void Awake()
    {
        Invoke("SpawnEnemy",2f);
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, spawnPoints.Count);
        // Instantiate ham spawn object
        var enemy = Instantiate(enemyPrefab, spawnPoints[index].transform.position, enemyPrefab.transform.rotation);
    }
}
