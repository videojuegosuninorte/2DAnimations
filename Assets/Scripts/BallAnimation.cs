using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimation : MonoBehaviour
{
    public Animator Animator;
    private bool _onTheFloor = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _onTheFloor = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _onTheFloor = false;
    }

    private void FixedUpdate()
    {
        Animator.SetBool("Floor", _onTheFloor);
    }
}
