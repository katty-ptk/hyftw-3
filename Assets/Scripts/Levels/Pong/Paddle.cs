using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the script that keeps track of inputs
public class Paddle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Rigidbody2D computer, ball;

    private float speed = 10f;

    void FixedUpdate() {
        if (Input.GetKey("w") || Input.GetKey("up")) {
            player.MovePosition(player.position + new Vector2(0, 1) * speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey("s") || Input.GetKey("down")) {
            player.MovePosition(player.position + new Vector2(0, -1) * speed * Time.fixedDeltaTime);
        }
    }
}