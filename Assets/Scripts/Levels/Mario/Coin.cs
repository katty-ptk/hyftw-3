using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public CoinCounter coinCounter;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			
		 coinCounter.AddCoin();
		 Debug.LogWarning("un banut");
			
			Destroy(this.gameObject);
		}
	}
}
