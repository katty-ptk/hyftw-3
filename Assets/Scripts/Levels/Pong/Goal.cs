using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip score;

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.gameObject.CompareTag("ball")) {
            audioSource.clip = score;
            audioSource.Play();

            collision.GetComponent<Ball>().Speed += 1; // up the speed of ball

            if ( gameObject.name == "Goal_Right" ){
                GameObject.Find("GameManager").GetComponent<PongLevelManager>().PlayerScored();
            } else {
                GameObject.Find("GameManager").GetComponent<PongLevelManager>().ComputerScored();
            }
        }
    }
}
