using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMario : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float JumpPower;
    private bool Right = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;



    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") || IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
            Flip();
     }
        void FixedUpdate()
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        }
        bool IsGrounded()
        {
            return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
        }


    private void Flip()
    {
        if ((Right && horizontal< 0f) || (!Right && horizontal> 0f))
        {
            Right = !Right;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
        

}
