using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBoss : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip win_clip;

    private void OnTriggerEnter2D(Collider2D collision) { 
        if (collision.CompareTag("bullet")) { 
            audioSource.clip = win_clip;
            audioSource.Play();
            manager.GetComponent<ChickenInvadersManager>().Win();
        }
    }
}
