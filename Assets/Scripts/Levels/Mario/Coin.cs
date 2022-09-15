using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public GameObject coinCounter;
	//public BoxCollider2D head;
	//public CircleCollider2D body;
    //BoxCollider2D head = gameObject.GetComponent<BoxCollider2D>();
	//CircleCollider2D body = gameObject.GetComponent<CircleCollider2D>();

//BoxCollider2D collider2D = new BoxCollider2D
    
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			
         coinCounter.GetComponent<CoinCounter>(). AddCoin1();
		 Debug.Log("un banut");
			
		Destroy(this.gameObject);
		 
		}
	}
	
}
