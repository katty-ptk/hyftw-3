using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{

    [SerializeField] GameObject manager;

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.CompareTag("Player") ) {
            Destroy(gameObject);

            manager.GetComponent<ChickenInvadersManager>().UpdateScore();
            Debug.Log("update");
        }
    }
}
