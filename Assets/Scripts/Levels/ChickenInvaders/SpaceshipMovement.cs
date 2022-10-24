using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{

    [SerializeField] private GameObject manager;

    private Rigidbody2D body;
    private ChickenInvadersManager chicken_invaders_manager;

    private float horizontal, vertical;

    [SerializeField] private  float speed = 10f;

    Gun[] guns;
    bool shoot;

    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioClip shot_clip;


    void Start() {
        body = GetComponent<Rigidbody2D>();
        guns = gameObject.GetComponentsInChildren<Gun>();
        chicken_invaders_manager =  manager.GetComponent<ChickenInvadersManager>();        
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        shoot = Input.GetKeyDown(KeyCode.Space);

        if (shoot && transform.GetChild(0)) { // if space was pressed
            shoot = false;
                
            // play sound
            sfxAudioSource.clip = shot_clip;
            sfxAudioSource.Play();

            foreach (Gun gun in guns) {
                if ( gun && gun.isActiveAndEnabled )
                    gun.Shoot();
            }
        }
    }

    void FixedUpdate() {
        body.velocity = new Vector2(horizontal * speed, vertical * speed); // spaceship movement based on input
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("gift")) {
            chicken_invaders_manager.UpdateScore();
            Destroy(collision.gameObject);
        }    

        if (collision.CompareTag("bomb")) {
            chicken_invaders_manager.DecreaseLife();
        }
    }
}
