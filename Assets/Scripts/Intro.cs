using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
public class Intro : MonoBehaviour
{

    [SerializeField] private List<Image> intro_images = new List<Image>();
    [SerializeField] private TextMeshProUGUI story_text;

    [SerializeField] private string[] story;

    private int image_index = -1;
    private string nextScene = "CharacterSelection";
    public void SkipIntro()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void NextImage()
    {
        if (image_index == intro_images.Count - 1)
        {
            SkipIntro();
            return;
        }

        image_index += 1;
        intro_images[image_index].DOFade(1f, 0.5f);
        story_text.text = story[image_index];
    }
}
