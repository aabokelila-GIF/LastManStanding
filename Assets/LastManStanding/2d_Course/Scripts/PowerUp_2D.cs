using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_2D : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Speed = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime *Speed);

        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
       //     other.GetComponent<Player_2D>().TripleShotActive();
                          
            Player_2D Player = other.GetComponent<Player_2D>();

            if (Player != null)
            {
                Player.TripleShotActive();
            }
            Destroy(gameObject);
        }
    }
}
