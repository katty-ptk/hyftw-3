using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// all transitions will be written inside this script
public class Fade : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Canvas img_parent;


    void Start(){
        FadeOut();
        StartCoroutine(WaitAndDisable());
    }

    public void FadeOut() {
        image.DOFade(0.0f, 1f);
    }

    public void FadeIn() {
        img_parent.gameObject.SetActive(true);
        image.DOFade(1f, 1f);
    }

    IEnumerator WaitAndDisable() {
        // disables fade canvas after image fades out
        yield return new WaitForSeconds(1.5f);
        img_parent.gameObject.SetActive(false);
    }
}
