using System;
using UnityEngine;

public class SSSWall : MonoBehaviour
{
    [SerializeField] private float offsetValue= 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided");

        if(collision.transform.position.y > 12 || collision.transform.position.y < -12)
        {
            collision.transform.position = new Vector2(collision.transform.position.x, -collision.transform.position.y  + offsetValue); //diff 12 & -12 condtion!
            
        }

        else
        {
            collision.transform.position = new Vector2(-collision.transform.position.x, collision.transform.position.y);
        }
            
    }
}
