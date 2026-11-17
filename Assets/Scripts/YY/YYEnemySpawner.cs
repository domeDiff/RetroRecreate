

using UnityEngine;

public class YYEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnOffsetX = 20f;
    [SerializeField] private float spawnOffsetY = 12f;
    [SerializeField] private float spawnTimer = 3f;


    private int[] validPosY = {12, -12};
    private Vector3 spawnPoint;

    //private void Start()
    //{
        
    //}
    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            spawnTimer = 3f;
        }

        GetNewSpawnPoint();
    }

    private Vector3 GetNewSpawnPoint()
    {
        int validPos_Y = Random.Range(0, validPosY.Length);
        return spawnPoint = new Vector3(Random.Range(-20f, 20f), validPos_Y , 0f);
    }
}
