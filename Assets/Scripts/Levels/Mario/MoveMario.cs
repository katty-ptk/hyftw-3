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
 private void Awake()
 {
    rb = GetComponent<Rigidbody2D>();
    camera = Camera.main;
 }

 private void Update()
 {
     HorizontalMove();
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
    position.x = Mathf.Clamp(position.x,Stanga.x,Dreapta.x);
    rb.MovePosition(position);

}


}
