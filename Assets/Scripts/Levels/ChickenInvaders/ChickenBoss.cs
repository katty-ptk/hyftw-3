using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBoss : MonoBehaviour
{
    [SerializeField] private GameObject manager, giftsManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip win_clip;
    [SerializeField] private GiftsSpawn giftsSpawnScript;

    private void Start()
    {
        giftsSpawnScript = giftsManager.GetComponent<GiftsSpawn>();
        InvokeRepeating("MoveRandomly", 1.0f, 2.0f);
    }

    private void MoveRandomly() {
        GetComponent<Transform>().DOMove(new Vector3(Random.Range(-8, 8), Random.Range(0, 4.25f), 0), 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            giftsSpawnScript.StartCoroutine(giftsSpawnScript.Spawn());
            audioSource.clip = win_clip;
            audioSource.Play();

            if (gameObject.transform.localScale.x <= 0.2f)
            {
                Destroy(gameObject);
                manager.GetComponent<ChickenInvadersManager>().Win();
            }
            gameObject.transform.DOScale(gameObject.GetComponent<Transform>().localScale - new Vector3(0.3f, 0.3f, 1f), 0.2f);
        }
    }
}