using System;
using Unity.VisualScripting;
using UnityEngine;

public class SSSWall : MonoBehaviour
{
    [SerializeField] private float offsetValueX = 2f;
    [SerializeField] private float offsetValueY = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided");

        if(collision.transform.position.y > 12)
        {
            collision.transform.position = new Vector2(collision.transform.position.x, -collision.transform.position.y  + offsetValueY);    
        }

        else if(collision.transform.position.y < -12)
        {
            collision.transform.position = new Vector2(collision.transform.position.x, -collision.transform.position.y - offsetValueY);
        }

        else if(collision.transform.position.x > 20)
        {
            collision.transform.position = new Vector2(-collision.transform.position.x + offsetValueX, collision.transform.position.y);
        }
        else
        {
            collision.transform.position = new Vector2(-collision.transform.position.x - offsetValueX, collision.transform.position.y);
        }
    }
}
