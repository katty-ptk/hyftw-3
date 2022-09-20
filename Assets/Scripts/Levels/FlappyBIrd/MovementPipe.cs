using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPipe : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed =1 ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
    }
}
