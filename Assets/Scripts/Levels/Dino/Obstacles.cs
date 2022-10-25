using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    
    int nrobstacle;
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    public GameObject obstacle5;
     public float maxtime =1;
    private float timer;
   public float height;
   public float destroytime;


     
    void Update()
    {
        Invoke("f",1);
    }
    void f ()
    {
        if (timer > maxtime)
        {
            nrobstacle = Random.Range(1,5);
        if (nrobstacle ==1)
        {
GameObject newObstacol = Instantiate(obstacle1);
Destroy(newObstacol,destroytime);
        }

        
        if (nrobstacle ==2)
        {
GameObject newObstacol = Instantiate(obstacle2);
Destroy(newObstacol,destroytime);
        }



        if (nrobstacle ==3)
        {
GameObject newObstacol = Instantiate(obstacle3);
Destroy(newObstacol,destroytime);
        }


        if (nrobstacle ==4)
        {
GameObject newObstacol = Instantiate(obstacle4);
Destroy(newObstacol,destroytime);
        }


        if (nrobstacle ==5)
    {
GameObject newObstacol = Instantiate(obstacle5);
Destroy(newObstacol,destroytime);
    }


       
            //GenerateObstacle();
            //newObstacol.transform.position = transform.position +  new Vector3 (0, Random.Range(-height,height),0);
            timer =0;
           // Destroy(newObstacol,destroytime);
        }
        timer += Time.deltaTime;
    }
    
   
}
