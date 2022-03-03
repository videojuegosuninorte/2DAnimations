using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTiles : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 2f;
    private Rigidbody2D _rigidbody2D;
    private float _horizontal;
    private bool _jumping = false;
    public Animator animator;
    private bool _isOnTheFloor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            _isOnTheFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Floor")
        //{
            _isOnTheFloor = false;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump") && _isOnTheFloor)
        {
            _jumping = true;
        }

    }

    // this is called evry time there is a physics update
    private void FixedUpdate()
    {
        
        animator.SetFloat("Speed", Mathf.Abs(_horizontal > 0 ? _horizontal : 0));

        if (_jumping)
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
            _jumping = false;
        } else
        {
            animator.SetBool("Jumping", false);
        }

        transform.position += new Vector3(_horizontal > 0 ? _horizontal : 0, 0, 0) * Time.fixedDeltaTime * Speed;
    }
}

