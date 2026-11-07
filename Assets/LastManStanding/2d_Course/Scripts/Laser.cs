using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] bool isEnemyLaser;
    void Update()
    {
        if (isEnemyLaser)
        {
            MoveDown();

        }
        else
        {

            MoveUp();

        }

    }

    void MoveDown()
    {
        transform.Translate(0, -1 * Speed * Time.deltaTime, 0);


        if (transform.position.y > -10)
        {

            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(gameObject);
        }
    }

    void MoveUp()
    {
        transform.Translate(0, 1 * Speed * Time.deltaTime, 0);


        if (transform.position.y > 10)
        {

            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(gameObject);
        }
    }

    public void AssignEnemyLaser()
    {
        isEnemyLaser = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isEnemyLaser == true)
        {
            Player_2D Player = collision.GetComponent<Player_2D>();

            if (Player != null)
            {
                {
                    Player.Damage();
                }

            }
        }
    }
}


