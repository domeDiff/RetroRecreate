using System;
using System.Threading;
using UnityEngine;

public class YYEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnOffsetX = 20f;
    [SerializeField] private float spawnOffsetY = 12f;
    [SerializeField] private float spawnTimer = 3f;

    private Vector3 spawnPoint;
    private void Start()
    {
        spawnPoint = new Vector3(spawnOffsetX, spawnOffsetY, 0f);
    }
    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        
        if(spawnTimer <= 0)
        {
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            spawnTimer = 3f;
        }
    }
}
