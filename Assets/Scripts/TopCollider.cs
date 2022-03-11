using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCollider : MonoBehaviour
{
    private bool firstCollision = false;
    public int level;
    public Level levelPrefab;
    // Start is called before the first frame update
    public void SetLevel(int level)
    {
        this.level = level;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!firstCollision)
        {
            MenuManager.Instance.SetScore(level);
            firstCollision = true;

            if (level == 10)
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.end);
            }
            else
            {

                float offset = 4.0f;

                if (transform.position.x == -5)
                {
                    var obj2 = Instantiate(levelPrefab, new Vector3(5, transform.position.y + offset, 0), Quaternion.identity);
                    obj2.SetLevel(level + 1);

                    //obj2 = Instantiate(levelPrefab, new Vector3(-5, transform.position.y + offset*2, 0), Quaternion.identity);
                    //obj2.SetLevel(level + 2);

                }
                else
                {
                    var obj = Instantiate(levelPrefab, new Vector3(-5, transform.position.y + offset, 0), Quaternion.identity);
                    obj.SetLevel(level + 1);

                    //obj = Instantiate(levelPrefab, new Vector3(5, transform.position.y + offset * 2, 0), Quaternion.identity);
                    //obj.SetLevel(level + 2);

                }

            }

        }
    }
}
