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

    private void OnCollisionStay2D(Collision2D collision)
    {
        jumping = true;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    jumping = true;
    //}

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        horizonal = h;

        if (Input.GetButton("Jump"))
        {
            doubleJump = true;
            jumping = true;
            //Debug.Log("Double jump");

        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizonal * HorizontalForce * Time.fixedDeltaTime, false, jumping, doubleJump);

        if (doubleJump)
        {
            //Debug.Log("Cancel Double jump");
        }

        doubleJump = false;
        jumping = false;
        JumpForce = 1;
    }

}
