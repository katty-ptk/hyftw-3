using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftsSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] gifts;
    [SerializeField] float left_limit, right_limit, spawn_seconds;

    private void Start() {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        while (true) {
            var wanted = Random.Range(left_limit, right_limit);
            var position = new Vector3(wanted, transform.position.y);
            GameObject obj = Instantiate(gifts[Random.Range(0, gifts.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(spawn_seconds);
            Destroy(obj, 2.5f);
        }
    }
}
