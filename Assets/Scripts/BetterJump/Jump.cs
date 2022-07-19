using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=7KiK0Aqtmzc&t=633s
public class Jump : MonoBehaviour
{
    [Range(1,10)]
    public float jumpVelocity;
    public float Speed = 5f;
    private float _horizontal;
    private bool _jumping = false;

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

        if (_jumping)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            _jumping = false;
        }
        transform.position += new Vector3(_horizontal, 0, 0) * Time.fixedDeltaTime * Speed;
    }
}
