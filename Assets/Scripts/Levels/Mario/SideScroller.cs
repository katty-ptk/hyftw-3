using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroller : MonoBehaviour
{
    // Start is called before the first frame update
   private Transform player;

   private void Awake()
   {
    player = GameObject.FindWithTag("Player").transform;
   }

   private void LateUpdate()
   {
    Vector3 pos = transform.position;
    pos.x =  Mathf.Max( pos.x,player.position.x);
    transform.position = pos;
   }
}
