using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    public float maxtime =1;
    private float timer;
   public GameObject pipe;
   public float height;
   public float destroytime ;

   
    void Update()
    {
        Invoke("f",1);
    }
    void f ()
    {
        if (timer > maxtime)
        {
            GameObject newpipe = Instantiate(pipe);
            newpipe.transform.position = transform.position +  new Vector3 (0, Random.Range(-height,height),0);
            timer =0;
            Destroy(newpipe,destroytime);
        }
        timer += Time.deltaTime;
    }
}
