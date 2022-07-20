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


    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            _jumping = true;
            
        }
    }

    private void FixedUpdate()
    {

        _grounded = GetComponent<CircleCollider2D>().IsTouchingLayers(mask);
        if (!_grounded)
        {
            _jumping = false;
        }
        if (_jumping)
        {
            //GetComponent<Rigidbody2D>().velocity += Vector2.up * jumpVelocity;  // affecting te velocity directly
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);  // using unity´s physics
            _jumping = false;
            _grounded = false;
        } 
        transform.position += new Vector3(_horizontal, 0, 0) * Time.fixedDeltaTime * Speed;
    }
}
