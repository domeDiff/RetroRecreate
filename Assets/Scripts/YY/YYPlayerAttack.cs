
using UnityEngine;

public class YYPlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit: " + collision.gameObject.name);

        Vector3 spawnPosition = Vector3.Lerp(
            transform.position,
            collision.transform.position,
            0.2f
        );

        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
