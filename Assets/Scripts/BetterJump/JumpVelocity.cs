using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=7KiK0Aqtmzc&t=633s
public class JumpVelocity : MonoBehaviour
{
    [Range(1,10)]
    public float jumpVelocity;
    public float Speed = 5f;
    public LayerMask mask;
    private float _horizontal;
    private bool _jumping = false;
    private bool _grounded;
    private float jumpHeight = 1;  // thge height of the player
    private Rigidbody2D rigidbody2D;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        // get the size of the gameObject
        var p1 = gameObject.transform.TransformPoint(0, 0, 0);
        var p2 = gameObject.transform.TransformPoint(1, 1, 0);
        var w = p2.x - p1.x;
        var jumpHeight = p2.y - p1.y;
    }


    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if (_horizontal != 0)
        {
            Debug.Log("Getting horizontal movement " + _horizontal);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumping = true;
        }

        _grounded = GetComponent<CircleCollider2D>().IsTouchingLayers(mask);
        if (!_grounded)
        {
            //Debug.Log("not grounded");
            _jumping = false;
            if (rigidbody2D.velocity.y < 0)
            {
                rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
                
                Debug.Log("Down gravity");
            }
            else if (rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
                Debug.Log("Up gravity");
            }
        }
    }

    public float JumpForceThingyCalculator(float wantedHeight, float weight, float g)
    {
        return weight * Mathf.Sqrt(-2 * wantedHeight * g);
    }

    private void FixedUpdate()
    {
        Debug.Log("_jumping " + _jumping + "velocity " + rigidbody2D.velocity.y);
        

        if (_jumping)
        {
            
            float requieredForce = JumpForceThingyCalculator(jumpHeight, rigidbody2D.mass, Physics2D.gravity.y * rigidbody2D.gravityScale) * jumpVelocity;
            GetComponent<Rigidbody2D>().velocity += Vector2.up * requieredForce;  // affecting te velocity directly
            _jumping = false;
            _grounded = false;
        }
        
        transform.position += new Vector3(_horizontal, 0, 0) * Time.fixedDeltaTime * Speed;
    }
}
