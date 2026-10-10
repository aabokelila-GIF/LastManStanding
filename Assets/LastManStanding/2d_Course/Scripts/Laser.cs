using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float Speed ;
 
    void Update()
    {
        transform.Translate(0,1 *Speed * Time.deltaTime, 0);
        

        if(transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
