using UnityEngine;
using System.Collections;

//https://www.youtube.com/watch?v=7KiK0Aqtmzc&t=633s
public class BetterJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumoMultiplier = 2f;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (rigidbody2D.velocity.y < 0)
        {
            rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump")){
            rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumoMultiplier - 1) * Time.deltaTime;
        }
    }
}
