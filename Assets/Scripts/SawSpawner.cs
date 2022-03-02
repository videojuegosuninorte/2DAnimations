using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawner : MonoBehaviour
{
    public GameObject Saw;
    void Start()
    {
        InvokeRepeating("SpawmOneSaw", Random.Range(0,2), Random.Range(3,5));
    }

    private void SpawmOneSaw()
    {
        Instantiate(Saw, transform.position, Quaternion.identity);
    }
}
