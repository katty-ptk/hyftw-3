using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ChickenInvadersManager : MonoBehaviour
{
    [SerializeField] private GameObject winCanas, collectIngredient, giftsManager, inventory_container;
    [SerializeField] private TextMeshProUGUI scoreText, winText;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Ingredient ingredient;

    int score;

    private void Start() {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void UpdateScore() {
        score += 1;
        scoreText.text = score.ToString();
        if (score == 10)
            Win();
    }

    private void Win() {
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
