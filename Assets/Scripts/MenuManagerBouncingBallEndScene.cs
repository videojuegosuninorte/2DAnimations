using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerBouncingBallEndScene : MonoBehaviour
{
    public TextMeshProUGUI TimeText;

    // Start is called before the first frame update
    void Start()
    {
        int Ending = PlayerPrefs.GetInt("Ending");
        TimeText.text = "Final time: " + Ending;
    }

    // Update is called once per frame
    public void OnClickEnd()
    {
        SceneManager.LoadScene("BouncingBall");
    }
}
