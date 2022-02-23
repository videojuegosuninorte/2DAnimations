using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestartWall : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player restart");
            collision.gameObject.transform.position = new Vector3(-7.44f, 3.61f, 0);
        }
    }
}
