using UnityEngine;

public class YYPlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit" + collision.gameObject.name);

        Instantiate(b)
    }
}