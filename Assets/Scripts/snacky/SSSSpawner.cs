using UnityEngine;

public class SSSSpawner : MonoBehaviour
{
    [SerializeField] private GameObject snackPrefab;

    private Vector2 spawnPoint;

    private void Awake()
    {
        spawnPoint = new Vector2(Random.Range(0, 5), Random.Range(0, 5));
    }

    public void SpawnSnack()
    {
        Instantiate(snackPrefab, spawnPoint, Quaternion.identity);
    }
}
