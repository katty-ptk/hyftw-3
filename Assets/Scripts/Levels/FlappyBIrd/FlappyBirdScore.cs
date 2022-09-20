using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlappyBirdScore : MonoBehaviour
{
   public double score = 0.00;
   public TextMeshProUGUI scoretext;

    // Update is called once per frame
    public void AddScore()
    {
        
        score += 1;
        scoretext.text = score.ToString("00");	

    }
    
    

}
