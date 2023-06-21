using System.Collections;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    public float speed = 30f;

    public string axis = "";

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
