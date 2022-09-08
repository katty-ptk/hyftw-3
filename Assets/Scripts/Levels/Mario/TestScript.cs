using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour

{
    public BoxCollider2D Collider1;
    public CircleCollider2D Collider2;
     void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider == Collider1 && GetComponent<Collider>().gameObject.tag == "Player")
        Debug.Log("1");

        if(col.collider == Collider2 && GetComponent<Collider>().gameObject.tag == "Player")
        Debug.Log("2");
    }
}
    

