using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public int coinCount = 0;
    public AudioSource audioS;
    public AudioClip coinsound;
    public TextMeshProUGUI cointext;
    void Start()
    {
       // audioS = GetComponent<AudioSource>();
      
    }
    public void AddCoin()
    {
        audioS.clip = coinsound;
        audioS.Play();
        coinCount += 1;
        cointext.text = coinCount.ToString("00");	

    }
}
