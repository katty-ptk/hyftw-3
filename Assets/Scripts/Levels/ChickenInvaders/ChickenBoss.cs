using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBoss : MonoBehaviour
{
    [SerializeField] private GameObject manager, giftsManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip win_clip;
    GiftsSpawn giftsSpawnScript;

    private void Start()
    {
        giftsSpawnScript = giftsManager.GetComponent<GiftsSpawn>();
        giftsSpawnScript.StartCoroutine(giftsSpawnScript.Spawn());
        InvokeRepeating("MoveRandomly", 1.0f, 2.0f);
    }

    private void MoveRandomly() {
        GetComponent<Transform>().DOMove(new Vector3(Random.Range(-8, 8), Random.Range(0, 4.25f), 0), 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            float random_range = Random.Range(0.02f, 0.2f);
            gameObject.transform.DOScale(gameObject.GetComponent<Transform>().localScale - new Vector3(random_range, random_range, 1f), 0.2f);

            if (gameObject.transform.localScale.x <= 0.25f) {
                manager.GetComponent<ChickenInvadersManager>().Win();
                Destroy(gameObject);
                audioSource.clip = win_clip;
                audioSource.Play();
            }

        }
    }
}
