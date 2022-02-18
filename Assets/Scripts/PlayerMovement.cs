using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D Rigidbody2D;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 dir = new Vector2(h, 0);

        animator.SetFloat("Speed", Mathf.Abs(h * speed));

        Rigidbody2D.velocity = dir.normalized * speed;

    }
}
