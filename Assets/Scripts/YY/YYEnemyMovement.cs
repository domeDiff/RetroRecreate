
using UnityEngine;

public class YYEnemyMovement : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float moveSpeed = 5f;

    private void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("YYPlayer");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (player == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            moveSpeed * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("YYPlayer"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
