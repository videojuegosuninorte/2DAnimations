using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    float timer = 0.0f;
    private GameState _gameState = GameState.start;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState gameState)
    {
        _gameState = gameState;
    }


    void Update()
    {
        switch (_gameState)
        {
            case GameState.start:
                timer += 0f;
                MenuManager.Instance.setTime(0);
                UpdateGameState(GameState.play);
                break;
            case GameState.play:
                timer += Time.deltaTime;
                MenuManager.Instance.setTime((int)(timer % 60));
                break;

            case GameState.end:
                timer += Time.deltaTime;
                PlayerPrefs.SetInt("Ending", (int)(timer % 60));
                SceneManager.LoadScene("BouncingBallEndScene");
                break;
        }

    }

    public enum GameState
    {
        start,
        play,
        end
    }
}
