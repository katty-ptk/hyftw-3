using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score;
   public TextMeshProUGUI txtscore;
    float timer;
    float maxtime;

    void Start()
    {
        score=0;
        maxtime= 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxtime)
        {
            score++;
            txtscore.text = score.ToString("00000");
            timer = 0;
        }
    }
}
