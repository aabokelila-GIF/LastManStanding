using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_2D : MonoBehaviour
{
    [SerializeField] float rotate_Speed = 0f;

    [SerializeField] GameObject exlposion_Effect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     transform.Rotate(Vector3.forward * rotate_Speed*Time.deltaTime);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Instantiate(exlposion_Effect,transform.position,Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(this.gameObject,0.15f);

        }
    }
}
