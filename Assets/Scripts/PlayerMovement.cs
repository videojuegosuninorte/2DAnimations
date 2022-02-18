using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 2f;
    private Rigidbody2D _rigidbody2D;
    private float _horizontal, _vertical;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (Input.GetButton("Jump") && Mathf.Abs(_rigidbody2D.velocity.y) == 0)
        {
            Debug.Log("Jumping");
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
        } else
        {
            animator.SetBool("Jumping", false);
        }

    }

    private void FixedUpdate()
    {
        Vector2 dir = new Vector2(_horizontal, 0);

        animator.SetFloat("Speed", Mathf.Abs(_horizontal));

        transform.position += new Vector3(_horizontal, 0, 0) * Time.fixedDeltaTime * Speed;
    }
}
