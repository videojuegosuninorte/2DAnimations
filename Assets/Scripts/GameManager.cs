using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    float timer = 0.0f;

    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int)(timer % 60);
        MenuManager.Instance.setTime(seconds);
    }
}
