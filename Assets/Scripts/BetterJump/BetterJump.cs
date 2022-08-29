using UnityEngine;
using System.Collections;

//https://www.youtube.com/watch?v=7KiK0Aqtmzc&t=633s
public class BetterJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        Debug.Log("rigidbody2D.velocity.y "+ rigidbody2D.velocity.y);

        if (Mathf.Approximately(rigidbody2D.velocity.y, 0f))
        {
            rigidbody2D.gravityScale = 1;
            Debug.Log("Steady gravity");
        } else { 
            if (rigidbody2D.velocity.y < 0)
            {
                //rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
                rigidbody2D.gravityScale = fallMultiplier;
                Debug.Log("Down gravity");
            } else if (rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump")){
                //rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumoMultiplier - 1) * Time.fixedDeltaTime;
                rigidbody2D.gravityScale = lowJumpMultiplier;
                Debug.Log("Up gravity");
            }
        }

    }
}
