using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public GameObject coinCounter;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			
		 coinCounter.GetComponent<CoinCounter>(). AddCoin();
		 Debug.LogWarning("un banut");
			
			Destroy(this.gameObject);
		}
	}
}
