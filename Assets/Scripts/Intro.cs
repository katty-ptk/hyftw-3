using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
public class Intro : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<Image> intro_images = new List<Image>();
    [SerializeField] private TextMeshProUGUI story_text, skip, click_to_learn;

    [SerializeField] private string[] story;

    private Coroutine display_line_coroutine;

    private int image_index = -1;
    private string nextScene = "CharacterSelection";

    private void Start(){
        click_to_learn.DOFade(0.5f, 0.5f);
        skip.DOFade(1f, 1f);
    }

    public void SkipIntro()
    {
        SceneManager.LoadScene(nextScene);
    }

    private IEnumerator DisplayLine( string line ) {
        story_text.text = ""; // empty the text
        audioSource.Play();
        audioSource.loop = true;

        foreach ( char letter in line.ToCharArray() ) {

            // if the line has finished loading, stop typing sounds
            if (System.Array.IndexOf(line.ToCharArray(), letter) == line.ToCharArray().Length - 1)
                audioSource.Stop();
            story_text.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void NextImage(){

        if (image_index == intro_images.Count - 1){
            SkipIntro();
            return;
        }

        if (click_to_learn.isActiveAndEnabled) click_to_learn.gameObject.SetActive(false);   // if player clicked once, the info text disappears

        image_index += 1;
        intro_images[image_index].DOFade(1f, 0.5f);

        // if line has not been completely shown then just skip it
        if (display_line_coroutine != null){
            StopCoroutine(display_line_coroutine);
        }

        display_line_coroutine = StartCoroutine(DisplayLine(story[image_index]));
    }
}
