using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float JumpForce = 2f;
    public float HorizontalForce = 1f;
    private Rigidbody2D rigidbody2D;
    public CharacterController2D controller;
    private float horizonal;
    private bool jumping;
    private bool r,l;
    private bool doubleJump = false;
    private float initialHeight = 0;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
       
        
    }

   
    private void OnCollisionStay2D(Collision2D collision)
    {
        jumping = true;


       


    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        horizonal = h;

        //if (h > 0)
        //{
        //    r = true;
        //} else
        //{
        //    if (h < 0)
        //    {
        //        l = true;
        //    }
            
        //}
        if (Input.GetButton("Jump"))
        {
            doubleJump = true;
            jumping = true;
            Debug.Log("Double jump");

        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizonal * HorizontalForce * Time.fixedDeltaTime, false, jumping, doubleJump);

        if (doubleJump)
        {
            Debug.Log("Cancel Double jump");
        }

        doubleJump = false;
        jumping = false;
        JumpForce = 1;

        //if (jumping)
        //{

        //    if (r)
        //    {
        //        //rigidbody2D.AddForce(new Vector2(HorizontalForce, 0), ForceMode2D.Force);
        //        //transform.Translate(-Vector3.right * 1 * Time.deltaTime);
        //        //rigidbody2D.velocity = transform.right * 2;
        //       // rigidbody2D.AddForce(rigidbody2D.velocity, ForceMode2D.Impulse);
        //        r = false;
        //    }
        //    else
        //    {
        //        if (l)
        //        {
        //            //  rigidbody2D.AddForce(new Vector2(HorizontalForce * -1, 0), ForceMode2D.Force);
        //            //rigidbody2D.velocity = transform.right * -2;
        //            //rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        //          //  rigidbody2D.AddForce(rigidbody2D.velocity, ForceMode2D.Impulse);
        //            l = false;
        //        } else
        //        {
        //            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(_startPos.x, transform.position.y) + (Vector2.up * _hightbuf), speed * Time.fixedDeltaTime);
        //           // rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        //        }
        //    }

        //    jumping = false;
    }

        
    
}
