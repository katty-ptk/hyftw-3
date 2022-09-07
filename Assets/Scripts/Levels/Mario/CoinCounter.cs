using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int coinCount = 0;
    private AudioSource audioS;
    public AudioClip coinsound;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
      
    }
    public void AddCoin()
    {
        audioS.clip = coinsound;
        audioS.Play();
        coinCount += 1;

    }
}
