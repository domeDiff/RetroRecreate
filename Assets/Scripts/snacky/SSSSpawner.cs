using UnityEngine;

public class SSSSpawner : MonoBehaviour
{
    [SerializeField] private GameObject snackPrefab;

    bool snackAvailable;

    private Vector2 spawnPoint;

    private void Awake()
    {
        spawnPoint = new Vector2(Random.Range(0, 5), Random.Range(0, 5));
    }

    private void Update()
    {
        if (snackAvailable)
            return;

        else
        {
            Instantiate(snackPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
