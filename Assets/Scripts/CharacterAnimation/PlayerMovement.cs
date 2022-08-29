using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 2f;
    private Rigidbody2D _rigidbody2D;
    private float _horizontal;
    private bool _jumping = false;
    public Animator animator;
    private bool m_FacingRight;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump") && Mathf.Abs(_rigidbody2D.velocity.y) == 0)
        {
            _jumping = true;
        }

        if (_horizontal < 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (_horizontal > 0 && m_FacingRight)
        {
            Flip();
        }

    }

    // this is called evry time there is a physics update
    private void FixedUpdate()
    {
        
        animator.SetFloat("Speed", Mathf.Abs(_horizontal));

        if (_jumping)
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
            _jumping = false;
        } else
        {
            animator.SetBool("Jumping", false);
        }


       // transform.position += new Vector3(_horizontal, 0, 0) * Time.fixedDeltaTime * Speed;

       transform.Translate(new Vector3(_horizontal, 0, 0) * Time.fixedDeltaTime * Speed);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

