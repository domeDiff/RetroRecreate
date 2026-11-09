using UnityEngine;

public class SSSSnack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SSSPlayer"))
        {
            gameObject.SetActive(false);
            SSSSpawner.SpawnSnack();
        }
    }
}
