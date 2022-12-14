using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bullet;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation * Vector2.up).normalized;
    }

    public void Shoot() {
        GameObject bulletToInstantiate = Instantiate(
            bullet.gameObject,
            transform.position,
            Quaternion.identity
        );

        Bullet bulletScript = bulletToInstantiate.GetComponent<Bullet>();
        bulletScript.direction = direction;

    }
}
