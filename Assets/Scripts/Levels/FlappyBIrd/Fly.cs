using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float velocity = 1;
public AudioSource audioS;
public AudioSource audioSGame;
    public AudioClip hitsound;
     public AudioClip flysound;
     public AudioClip gamesound;

//private bool dead = false;
private Animator anim;
public float  timer = 1f;
    private Rigidbody2D rb;
    public GameObject canvas;
    // Start is called before the first frame update
     public FlyManager script;
    void Start()
    {
        audioSGame.clip = gamesound;
        audioSGame.Play();
         audioSGame.loop = true;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       
    }
        

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
        
         rb.velocity = Vector2.up * velocity;
         audioS.clip = flysound;
        audioS.Play();

        }
       
    }
    void StopTime ()
    {
        Time.timeScale = 0;
    }
    void OnCollisionEnter2D(Collision2D  collider)
	{
		if (collider.gameObject.tag == "Pipe")
		{
           audioS.clip = hitsound;
        audioS.Play();
            script.GameOver();


        }
    }
}
