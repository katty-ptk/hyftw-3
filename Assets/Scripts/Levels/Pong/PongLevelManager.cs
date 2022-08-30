using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PongLevelManager : MonoBehaviour
{
    [Header("Ball")]
    [SerializeField] private GameObject ball;

    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject player_goal;

    [Header("Computer")]
    [SerializeField] private GameObject computer;
    [SerializeField] private GameObject computer_goal;

    [Header("UI Text")]
    [SerializeField] private GameObject player_text;
    [SerializeField] private GameObject computer_text;
    [SerializeField] private GameObject win_text;

    [Header("Canvases")]
    [SerializeField] private Canvas fade_canvas, win_canvas;

    [Header("Ingredient")]
    [SerializeField] private Ingredient pong_ingredient;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip win;


    private int player_score, computer_score;
    private Vector3 player_start_position, computer_start_position;

    private void Start() {
        player_start_position = player.GetComponent<Transform>().position;
        computer_start_position = computer.GetComponent<Transform>().position;
    }

    private void Update(){
        if (player_score == 5) {
            Win();
            player_score = 0;
        }
    }

    private void ResetPosition(){
        ball.GetComponent<Ball>().Reset();  // spawns ball to (0, 0)
        player.GetComponent<Transform>().position = player_start_position;
        computer.GetComponent<Transform>().position = computer_start_position;
    }

    public void PlayerScored() {
        player_score += 1;
        player_text.GetComponent<TextMeshProUGUI>().text = player_score.ToString(); // updates score on screen
        ResetPosition();
    }

    public void ComputerScored(){
        computer_score += 1;
        computer_text.GetComponent<TextMeshProUGUI>().text = computer_score.ToString(); // updates score on screen
        ResetPosition();
    }

    private void Win() {
        audioSource.clip = win;
        audioSource.Play();
        win_canvas.gameObject.SetActive(true);
        win_text.GetComponent<Transform>().DOScale(new Vector3(2, 2, 1), 1f);
        win_text.GetComponent<Rigidbody2D>().DORotate(360f, 2f);
        //fade_canvas.gameObject.SetActive(true);
        //gameObject.GetComponent<Fade>().FadeIn();
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        computer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
