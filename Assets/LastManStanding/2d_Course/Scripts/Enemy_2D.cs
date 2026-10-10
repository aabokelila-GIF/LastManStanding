using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy_2D : MonoBehaviour
{
   
    [SerializeField] float Speed = 1f;
   // [SerializeField] GameObject Laser;

    
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * Speed * (Time.deltaTime));

        if (transform.position.y < -4)
        {
            float RandomX = Random.RandomRange(-7, 7);
            transform.position = new Vector3(RandomX, 5, 0);
        }
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {

            other.GetComponent<Player_2D>().Damage();
            Debug.Log("PlayerDamaged");
            Destroy(this.gameObject);

        }


        if (other.gameObject.CompareTag("Laser"))
        {
           Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}
