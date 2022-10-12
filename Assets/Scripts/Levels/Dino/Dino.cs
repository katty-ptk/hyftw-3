using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public GameObject stand;
    public GameObject crouch;
    Rigidbody2D rb;
    bool isjumping;
    // Start is called before the first frame update
    void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
        isjumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && isjumping ==false)
        {
            rb.velocity = new Vector3(0, 20, 0);
            isjumping = true;
        }
    
    if(Input.GetKeyDown("down") && isjumping ==false)
        {
           crouch.SetActive(true);
           stand.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        isjumping = false;
    }
}
