using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Vector3 startPosition;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip tap;

    private float x, y;

    private void Start() {
        startPosition = transform.position;
        Launch();
    }
    
    // Getter used in Goal.cs to up the speed of the ball
    public float Speed {
        get {
            return speed;
        }

        set {
            speed = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if ( collision.gameObject.CompareTag("Player")) {
            audioSource.clip = tap;
            audioSource.Play();
        }
    }

    // lets us launch the ball in both directions
    private void Launch() {
        if (Random.Range(0, 2) == 0)
            x = -1;
        else
            x = 1;

        if (Random.Range(0, 2) == 0)
            y = -1;
        else
            y = 1;

        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void Reset() {
        // ball goes to (0, 0)
        rb.velocity = Vector2.zero;
        transform.position = startPosition;

        Launch();
    }
}
