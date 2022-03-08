using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float JumpForce = 15f;
    public float HorizontalForce = 1f;
    private Rigidbody2D rigidbody2D;
    private CharacterController controller;
    private bool jumping;
    private bool r,l;


    private void Awake()
    {
    }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        controller = GetComponent<CharacterController>();
    }

   
    private void OnCollisionStay2D(Collision2D collision)
    {
        //jumping = true;
        
        //if (r || l)
        //{
        //    if (r)
        //        rigidbody2D.AddForce(new Vector2(HorizontalForce, JumpForce/2), ForceMode2D.Impulse);

        //    if (l)
        //        rigidbody2D.AddForce(new Vector2(HorizontalForce*-1, JumpForce/2).normalized, ForceMode2D.Impulse);
        //    //  rigidbody2D.AddForce(new Vector2(HorizontalForce * -1, 0), ForceMode2D.Force);
        //    //rigidbody2D.velocity = transform.right * -2;
        //    //rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        //    //  rigidbody2D.AddForce(rigidbody2D.velocity, ForceMode2D.Impulse);

        //    r = false;
        //    l = false;
        //} else
        //{
        //    rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        //    rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (h > 0)
        {
            r = true;
        } else
        {
            if (h < 0)
            {
                l = true;
            }
            
        }
        if (Input.GetButton("Jump"))
        {
            jumping = true;
        }
    }

    private void FixedUpdate()
    {
       
        if (jumping)
        {
            
            if (r)
            {
                //rigidbody2D.AddForce(new Vector2(HorizontalForce, 0), ForceMode2D.Force);
                //transform.Translate(-Vector3.right * 1 * Time.deltaTime);
                //rigidbody2D.velocity = transform.right * 2;
               // rigidbody2D.AddForce(rigidbody2D.velocity, ForceMode2D.Impulse);
                r = false;
            }
            else
            {
                if (l)
                {
                    //  rigidbody2D.AddForce(new Vector2(HorizontalForce * -1, 0), ForceMode2D.Force);
                    //rigidbody2D.velocity = transform.right * -2;
                    //rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                  //  rigidbody2D.AddForce(rigidbody2D.velocity, ForceMode2D.Impulse);
                    l = false;
                } else
                {
                    //transform.position = Vector2.MoveTowards(transform.position, new Vector2(_startPos.x, transform.position.y) + (Vector2.up * _hightbuf), speed * Time.fixedDeltaTime);
                   // rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                }
            }

            jumping = false;
        }

        
    }
}
