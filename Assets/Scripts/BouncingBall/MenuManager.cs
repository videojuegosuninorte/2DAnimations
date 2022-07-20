using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimeText;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        
    }

    public void setTime(int secs)
    {
        TimeText.text = "Sec: " + secs;
    }

    public void SetScore(int y)
    {
        ScoreText.text = "Level: "+y.ToString();
    }
}
