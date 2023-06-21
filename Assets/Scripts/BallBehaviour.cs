using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float speed = 30f;

    float hitFactor(Vector2 ballPos, Vector2 raketPos, float racketHeight)
    {
        return (ballPos.x - raketPos.y) / racketHeight;
    }

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hit the left racket?
        if(collision.gameObject.name == "RacketLeft")
        {
            //calculate hit factor
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            //calculate direction, make lenth=1 via .normailze
            Vector2 direction = new Vector2(1, y).normalized;

            //set velocity with direction * speed
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        //hit the right racket?
        if (collision.gameObject.name == "RacketRight")
        {
            //calculate hit factor
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            //calculate direction, make lenth=1 via .normailze
            Vector2 direction = new Vector2(-1, y).normalized;

            //set velocity with direction * speed
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }
}
