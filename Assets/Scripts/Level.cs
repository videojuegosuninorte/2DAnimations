using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update

    public int level = 0;
    private bool firstCollision = false;
    public Level levelPrefab;


    public void SetLevel(int level)
    {
        this.level = level;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!firstCollision)
        {
            MenuManager.Instance.SetScore(level);
            firstCollision = true;

            if (level == 3) {
                GameManager.Instance.UpdateGameState(GameManager.GameState.end);
            } else { 

                if (transform.position.x == -5)
                {
                    var obj2 = Instantiate(levelPrefab, new Vector3(5, transform.position.y + 3.5f, 0), Quaternion.identity);
                    obj2.SetLevel(level + 1);

                }
                else
                {
                    var obj = Instantiate(levelPrefab, new Vector3(-5, transform.position.y + 3.5f, 0), Quaternion.identity);
                    obj.SetLevel(level + 1);

                }

            }

        }
    }

    void Start()
    {
        
    }


}
