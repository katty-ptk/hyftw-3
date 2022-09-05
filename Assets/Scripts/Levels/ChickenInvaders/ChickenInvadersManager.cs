using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ChickenInvadersManager : MonoBehaviour
{
    [SerializeField] private GameObject winCanas, collectIngredient;
    [SerializeField] private TextMeshProUGUI scoreText, winText;

    int score;

    private void Start() {
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        //Debug.Log(score);
        
    }

    public void UpdateScore() {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void Win() {
        winCanas.SetActive(true);
        winText.DOFade(1f, 0.5f);
        StartCoroutine(WaitAndShowCollect());
    }

    private IEnumerator WaitAndShowCollect() {
        yield return new WaitForSeconds(1.5f);
        winText.DOFade(0f, 0.5f);
        collectIngredient.SetActive(true);
    }
}
