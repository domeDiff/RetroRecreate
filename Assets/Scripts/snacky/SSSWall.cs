using UnityEngine;

public class SSSWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        Vector2 collidePosition = new Vector2(collision.transform.position.x, collision.transform.position.y);

        collision.transform.position = new Vector2(-collision.transform.position.x, collision.transform.position.y);
    }
}
