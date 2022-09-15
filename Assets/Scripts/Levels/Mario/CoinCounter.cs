using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public double coinCount = 0.00;
    public AudioSource audioS;
    public AudioClip coinsound;
    public TextMeshProUGUI cointext;
    void Start()
    {
       // audioS = GetComponent<AudioSource>();
      
    }
    /*public void AddCoin0()
    {
        audioS.clip = coinsound;
        audioS.Play();
        coinCount += 0.5;
        cointext.text = coinCount.ToString("00");	

    }*/
    public void AddCoin1()
    {
        audioS.clip = coinsound;
        audioS.Play();
        coinCount += 1;
        cointext.text = coinCount.ToString("00");	

    }
}
