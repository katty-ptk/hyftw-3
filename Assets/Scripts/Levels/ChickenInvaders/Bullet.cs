using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2( 0, 1 ),
                                     velocity;

    [SerializeField] private float speed = 5f;

    [SerializeField] private Sprite bullet_2;

    private void Start() {
        Destroy( gameObject, 3 );
    }

    private void Update() {
        velocity = direction * speed;
    }

    private void FixedUpdate() {
        Vector2 pos = transform.position;
        pos += velocity * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.gameObject.CompareTag("chicken")) {  // if bullet touched chicken
            collision.gameObject.transform.DOScale(0f, 0.3f); // transition into disappearing
            StartCoroutine(WaitAndDestroyChicken(collision.gameObject));
        }
    }

    private IEnumerator WaitAndDestroyChicken( GameObject chicken) {
        yield return new WaitForSeconds(0.5f);
       Destroy(chicken);
    }
}
