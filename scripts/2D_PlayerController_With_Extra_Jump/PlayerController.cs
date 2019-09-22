using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveinput;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps; 
    public int extrajumpsValue; 



     void Start()
    {
        extraJumps = extrajumpsValue; 
        rb = GetComponent<Rigidbody2D>();   
    }

   void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);
        moveinput = Input.GetAxis("Horizontal");
        Debug.Log(moveinput);
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);  
        if (facingRight == false && moveinput > 0)
        {
            flip();
        }
        else if (facingRight == true && moveinput < 0)
        {
            flip();
        }

        void flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler; 
        }


    }
   void Update()
    {

        {
            if (isGrounded == true)
            { extraJumps = extrajumpsValue; }

            if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
    }

}
