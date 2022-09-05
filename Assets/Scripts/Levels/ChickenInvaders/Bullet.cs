using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    private float speed = 8f;
    private Vector2 target = new Vector2(0.0f, 2.33f);

    private bool isLaunching = false;

    [SerializeField] private AudioSource audioSource;

    private void FixedUpdate() {
        if ( !isLaunching && gameObject != null ) {
            transform.position = Vector2.MoveTowards(transform.position, gameObject.transform.parent.position, speed); // keep bullets hidden behind spaceship
        }
    }

    public void LaunchBullet( GameObject bullet ) {
        if (bullet != null ) {
            audioSource.Play();
            bullet.transform.DOMoveY(target.y, 0.5f);   // smooth shot
            isLaunching = true; // this bullet will not keep following the spaceship
            StartCoroutine(WaitAndDestroy(bullet));
        }
    }

    // if the bullet reached the target, destroy it after 1 second
    private IEnumerator WaitAndDestroy( GameObject bulletToDestroy ){
        if (bulletToDestroy != null ) {
            yield return new WaitForSeconds(1f);
            Destroy(bulletToDestroy); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.gameObject.CompareTag("chicken")) {  // if bullet touched chicken
            // Destroy(collision.gameObject);
            collision.gameObject.transform.DOScale(0f, 0.3f); // transition into disappearing
        }
    }
}
