using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update

    public int TheLevel = 0;
    private bool firstCollision = false;
    public Level levelPrefab;


    public void SetLevel(int level)
    {
        this.TheLevel = level;
        TopCollider top = GetComponentInChildren<TopCollider>();
        top.SetLevel(level);
    }
    

}
