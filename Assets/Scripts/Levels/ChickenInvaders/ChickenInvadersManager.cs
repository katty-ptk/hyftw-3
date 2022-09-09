using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ChickenInvadersManager : MonoBehaviour
{
    [SerializeField] private GameObject winCanas, collectIngredient, giftsManager, inventory_container;
    [SerializeField] private GameObject chickenBoss, chickensManager, spaceship;
    [SerializeField] private Sprite bullet_2;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip chicken_boss_clip, win_clip, bg_music;
    [SerializeField] private TextMeshProUGUI scoreText, winText;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Ingredient ingredient;

    int score;

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

    private void ShowChickenBoss() {
        audioSource.clip = chicken_boss_clip;
        audioSource.Play();
        chickenBoss.SetActive(true);
        chickenBoss.transform.DOScale(1f, 1f);

        if ( score > 10 && spaceship.transform.childCount > 0) {
            for ( int i = 0; i < spaceship.transform.childCount; i++) {
                spaceship.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = bullet_2;
            }
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
}
