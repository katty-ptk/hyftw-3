using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ChickenInvadersManager : MonoBehaviour
{
    [SerializeField] private GameObject winCanas, loseCanvas, tryAgainCanvas, collectIngredient, giftsManager, inventory_container;
    [SerializeField] private GameObject chickenBoss, chickensManager, spaceship;
    [SerializeField] private Gun[] guns;
    [SerializeField] private Sprite bullet_2;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip chicken_boss_clip, win_clip, bg_music;
    [SerializeField] private TextMeshProUGUI scoreText, lifeText, winText, loseText, power_up;
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

        if ( (score >= 5 && score < 10 && !guns[1].enabled) || (score >= 10 && !guns[4].enabled) )
            ShowPowerUp();  

        if (score >= 5 && score < 10)
        {
            guns[1].enabled = true;
            guns[3].enabled = true;
        }
        else if (score >= 10)
        {
            guns[2].enabled = true;
            guns[4].enabled = true;
        }

    }

    void ShowPowerUp() {
        power_up.DOFade(1f, 0.3f);
        StartCoroutine(HidePowerUp());
    }

    IEnumerator HidePowerUp() {
        yield return new WaitForSeconds(1f);
        power_up.DOFade(0f, 0.3f);
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
    }

    public void Win() {
        loseCanvas.SetActive(false);
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
        inventory.addIngredient(
            ingredient, 
            inventory_container.transform, 
            collectIngredient.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite
        );

        SceneManager.LoadScene("Dino");
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
