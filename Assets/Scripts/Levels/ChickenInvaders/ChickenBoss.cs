using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBoss : MonoBehaviour
{
    [SerializeField] private GameObject manager, giftsManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip win_clip;
    [SerializeField] private GiftsSpawn giftsSpawnScript;

    private void Start() {
        giftsSpawnScript = giftsManager.GetComponent<GiftsSpawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision) { 
        if (collision.CompareTag("bullet")) {
            giftsSpawnScript.StartCoroutine(giftsSpawnScript.Spawn());
            audioSource.clip = win_clip;
            audioSource.Play();
            manager.GetComponent<ChickenInvadersManager>().Win();
        }
    }
}
