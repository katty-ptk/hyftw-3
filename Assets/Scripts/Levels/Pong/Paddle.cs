using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the script that keeps track of inputs
public class Paddle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Rigidbody2D computer, ball;

    private float speed = 15f;

    private void Start() {
        LaunchComputer();   // computer goes up a bit and then bounces up and down just like the ball does
    }

    void FixedUpdate() {
        if (Input.GetKey("w") || Input.GetKey("up")) {
            player.MovePosition(player.position + new Vector2(0, 1) * speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey("s") || Input.GetKey("down")) {
            player.MovePosition(player.position + new Vector2(0, -1) * speed * Time.fixedDeltaTime);
        }

       // computer.transform.position = Vector2.MoveTowards(computer.position, new Vector2(computer.position.x, ball.transform.position.y), speed * Time.fixedDeltaTime);
    }

    void LaunchComputer() {
        computer.velocity = new Vector2(computer.position.x, speed);
    }
}