using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InputMaster controls;

    private void Awake()
    {
        controls.Player.Shoot.performed += _ => Shoot();
    }

    void Shoot()
    {
        Debug.Log("Fire");
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
