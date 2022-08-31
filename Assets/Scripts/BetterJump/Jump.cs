using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=7KiK0Aqtmzc&t=633s
public class Jump : MonoBehaviour
{

    public float WantedHeight;
    public float Speed = 5f;
    public LayerMask FloorMask;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private float _horizontal;
    private bool _jumping = false;
    private bool _grounded;
    private Rigidbody2D rb;
    private Vector3 _initialPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) // "Trigger"
        {
            gameObject.transform.position = _initialPosition;
            rb.velocity = new Vector2(0,0);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        _initialPosition = gameObject.transform.position;
    }


    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump pressed");
            if (_grounded)
                _jumping = true;
        }

        _grounded = GetComponent<CircleCollider2D>().IsTouchingLayers(FloorMask);


        if (!_grounded)
        {
            Debug.Log("On the air");
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = fallMultiplier;
                //Debug.Log("Down gravity");
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.gravityScale = lowJumpMultiplier;
                //Debug.Log("Up gravity");
            }
        }
        else
        {
            //Debug.Log("grounded");
            rb.gravityScale = 1;
        }


    }

    public float JumpForceCalculator(float wantedHeight, float weight, float g)
    {
        return weight * Mathf.Sqrt(-2 * wantedHeight * g);
    }

    private void FixedUpdate()
    {
        //Debug.Log("_jumping " + _jumping + " velocity " + rigidbody2D.velocity.y);
        
        if (_jumping)
        {
            Debug.Log("Jumping");
            float requieredForce = JumpForceCalculator(WantedHeight, rb.mass, Physics2D.gravity.y * rb.gravityScale) ;
            rb.AddForce(new Vector2(0, requieredForce), ForceMode2D.Impulse);  // using unity´s physics
            _jumping = false;
            _grounded = false;
        }
        
        transform.position += new Vector3(_horizontal, 0, 0) * Time.fixedDeltaTime * Speed;
    }
}
