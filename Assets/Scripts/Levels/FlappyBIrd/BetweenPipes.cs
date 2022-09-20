using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenPipes : MonoBehaviour
{
    // Start is called before the first frame update
    public FlappyBirdScore score;
    void Start()
    {
        
    }
void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Bird")
		{
			
         score.GetComponent<FlappyBirdScore>(). AddScore();
        }
    }



}
