using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=7KiK0Aqtmzc&t=633s
public class Jump : MonoBehaviour
{
    [Range(1,10)]
    public float jumpVelocity;
    public float Speed = 5f;
    public LayerMask mask;
    private float _horizontal;
    private bool _jumping = false;
    private bool _grounded;
    private float jumpTime;
    private float jumpHeight = 1;  // thge height of the player
    private Rigidbody2D rigidbody2D;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        var p1 = gameObject.transform.TransformPoint(0, 0, 0);
        var p2 = gameObject.transform.TransformPoint(1, 1, 0);
        var w = p2.x - p1.x;
        var jumpHeight = p2.y - p1.y;
    }


    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            _jumping = true;
            jumpTime = 0;

        }
    }

    private void FixedUpdate()
    {

        _grounded = GetComponent<CircleCollider2D>().IsTouchingLayers(mask);
        if (!_grounded)
        {
            //Debug.Log("not grounded");
            _jumping = false;
            if (rigidbody2D.velocity.y < 0)
            {
                //rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
                rigidbody2D.gravityScale = fallMultiplier;
                Debug.Log("Down gravity");
            }
            else if (rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                //rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumoMultiplier - 1) * Time.fixedDeltaTime;
                rigidbody2D.gravityScale = lowJumpMultiplier;
                Debug.Log("Up gravity");
            }
        } else
        {
            //Debug.Log("grounded");
            rigidbody2D.gravityScale = 1;
        }
        if (_jumping)
        {
            //GetComponent<Rigidbody2D>().velocity += Vector2.up * jumpVelocity;  // affecting te velocity directly
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rigidbody2D.gravityScale));
            Debug.Log("jumpForce "+ jumpForce+
                " gravityScale " + rigidbody2D.gravityScale +
                " Physics2D.gravity.y "+ Physics2D.gravity.y +
                " jumpHeight" + jumpHeight);
            rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);  // using unity´s physics
            _jumping = false;
            _grounded = false;
        } 
        transform.position += new Vector3(_horizontal, 0, 0) * Time.fixedDeltaTime * Speed;
    }
}
