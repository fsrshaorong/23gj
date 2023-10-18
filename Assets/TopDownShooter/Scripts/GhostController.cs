using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float speed;
    private Vector2 lookDirection;
    private float x;
    private float y;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 position = rigidbody2D.position;
        position.x += speed * Time.fixedDeltaTime * x;
        position.y += speed * Time.fixedDeltaTime * y;
        rigidbody2D.MovePosition(position);
    }
}
