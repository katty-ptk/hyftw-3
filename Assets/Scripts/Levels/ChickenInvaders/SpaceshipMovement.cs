using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{

    [SerializeField] private GameObject manager;

    private Rigidbody2D body;

    private float horizontal, vertical;
    private bool isShooting;

    [SerializeField] private  float speed = 10f;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        isShooting = Input.GetKeyDown(KeyCode.Space);

        if (isShooting && transform.GetChild(0)) { // if space was pressed
            Transform child = transform.GetChild(0);
            child.GetComponent<Bullet>().LaunchBullet(child.gameObject);    // shoot
            Instantiate(child, transform);
        }
    }

    void FixedUpdate() {
        body.velocity = new Vector2(horizontal * speed, vertical * speed); // spaceship movement based on input
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("gift")) {
            manager.GetComponent<ChickenInvadersManager>().UpdateScore();
            Destroy(collision.gameObject);
        }    
    }
}
