using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SubsystemsImplementation;

public class ChickenInvadersManager : MonoBehaviour
{
    [SerializeField] private GameObject winCanas, loseCanvas, tryAgainCanvas, collectIngredient, giftsManager, inventory_container;
    [SerializeField] private GameObject chickenBoss, chickensManager, spaceship;
    [SerializeField] private Sprite bullet_2;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip chicken_boss_clip, win_clip, bg_music;
    [SerializeField] private TextMeshProUGUI scoreText, lifeText, winText, loseText;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Ingredient ingredient;
    
    int score, life = 3;

    private void Start() {
        score = 0;
        scoreText.text = score.ToString();        
    }

    private void Update(){
        if ( chickensManager.transform.childCount == 1 ) {
            ShowChickenBoss();
            enabled = false;
        }
    }

    public void UpdateScore() {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void DecreaseLife() {
        life -= 1;
        lifeText.text = life.ToString();
        lifeText.transform.parent.DOScale(2f, 0.5f);
        StartCoroutine(HideLife());
        print(life);

        if ( life == 0) {
            Destroy(spaceship);
            Lose();
        }
    }

    private IEnumerator HideLife() {
        yield return new WaitForSeconds(0.7f);
        lifeText.transform.parent.DOScale(0f, 0.2f);
    }

    private void ShowChickenBoss() {
        audioSource.clip = chicken_boss_clip;
        audioSource.Play();
        chickenBoss.SetActive(true);
        chickenBoss.transform.DOScale(1f, 1f);

        if ( score > 10 ) {
        /*    for ( int i = 0; i < spaceship.transform.childCount; i++) {
                spaceship.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = bullet_2;
            }*/
        }
    }

    public void Win() { 
        giftsManager.GetComponent<GiftsSpawn>().StopAllCoroutines();
        winCanas.SetActive(true);
        winText.DOFade(1f, 0.5f);
        StartCoroutine(WaitAndShowCollect());
    }

    private IEnumerator WaitAndShowCollect() {
        yield return new WaitForSeconds(1.5f);
        winText.DOFade(0f, 0.5f);
        collectIngredient.SetActive(true);
    }

    public void CollectIngredient() {
        inventory.addIngredient(ingredient, inventory_container.transform, collectIngredient.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite);

        for (int i = 0; i < inventory.Inv.Count; i++) {
            Debug.Log(inventory.Inv[i].name);
        }
    }

    public void Lose() {
        giftsManager.GetComponent<GiftsSpawn>().StopAllCoroutines();
        loseCanvas.SetActive(true);
        loseText.DOFade(1f, 0.5f);
        StartCoroutine(WaitAndShowTryAgain());
    }

    private IEnumerator WaitAndShowTryAgain() {
        yield return new WaitForSeconds(1.5f);
        loseText.DOFade(0f, 0.5f);
        tryAgainCanvas.SetActive(true);
    }
}
