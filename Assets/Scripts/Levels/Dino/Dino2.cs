using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino2 : MonoBehaviour
{
     public GameObject stand;
    public GameObject crouch;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("down"))
        {
           stand.SetActive(true);
           crouch.SetActive(false);
        }
    }
}
