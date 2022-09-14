using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMario : MonoBehaviour
{
private new Camera camera;
 private Vector2 velocity;
 private Rigidbody2D rb;
 private float InputAxis;
 public float speed = 8f;
 public  bool Right = true;
  public float maxJumpHeight = 5f;	
  public float maxJumpTime = 1f;
  public float JumpPower => (2f *maxJumpHeight) / (maxJumpTime /2f);
  public float gravity => (-2f* maxJumpHeight) / Mathf.Pow((maxJumpTime /2f),2);
  public bool grounded {get; private set;}
  public bool jumping {get; private set;}
 private void Awake()
 {
    rb = GetComponent<Rigidbody2D>();
    camera = Camera.main;
 }

 private void Update()
 {
    HorizontalMove();
     Flip();
    grounded = rb.Raycast(Vector2.down);
    if(grounded)
    {
        GroundedMovement();
    }
    ApplyGravity();
 }
 private void ApplyGravity()
 {
    bool falling = velocity.y <0f || !Input.GetButtonDown("Jump");
    float multiplier = (falling ? 2f : 1f);
    velocity.y += gravity * Time.deltaTime;
    velocity.y = Mathf.Max(velocity.y, gravity / 2f);
 }
 private void GroundedMovement()
 {
    velocity.y = Mathf.Max(velocity.y, 0f);
    jumping = velocity.y >0f;

    if(Input.GetButtonDown("Jump"))
    {
        velocity.y = JumpPower;
        jumping = true;
    }
 }
 private void HorizontalMove()
 {
InputAxis = Input.GetAxis("Horizontal");
velocity.x = Mathf.MoveTowards(velocity.x, InputAxis*speed, speed* Time.deltaTime);
 }

private  void FixedUpdate()
{
    Vector2 position = rb.position;
    
  
position += velocity* Time.fixedDeltaTime;
    
    Vector2 Stanga = camera.ScreenToWorldPoint(Vector2.zero);
    Vector2 Dreapta = camera.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
    position.x = Mathf.Clamp(position.x,Stanga.x+0.5f,Dreapta.x-0.5f);

    rb.MovePosition(position);

}
private void Flip()
    {
        if ((Right && InputAxis< 0f) || (!Right && InputAxis> 0f))
        {
            Right = !Right;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


}
