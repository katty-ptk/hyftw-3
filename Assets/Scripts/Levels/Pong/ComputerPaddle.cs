using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private Rigidbody2D ball;

    private float speed = 10f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    public void ResetPosition(){
        rigidbody.velocity = Vector2.zero;
        rigidbody.position = new Vector2(rigidbody.position.x, 0f);
    }

    private void FixedUpdate(){
        // Check if the ball is moving towards the paddle (positive x velocity)
        // or away from the paddle (negative x velocity)
        if (ball.velocity.x > 0f)
        {
            // Move the paddle in the direction of the ball to track it
            if (ball.position.y > rigidbody.position.y)
            {
                rigidbody.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < rigidbody.position.y)
            {
                rigidbody.AddForce(Vector2.down * speed);
            }
        }
        else
        {
            // Move towards the center of the field and idle there until the
            // ball starts coming towards the paddle again
            if (rigidbody.position.y > 0f)
            {
                rigidbody.AddForce(Vector2.down * speed);
            }
            else if (rigidbody.position.y < 0f)
            {
                rigidbody.AddForce(Vector2.up * speed);
            }
        }
    }
}
