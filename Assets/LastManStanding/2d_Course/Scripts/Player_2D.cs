using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_2D : MonoBehaviour
{
    [SerializeField] GameObject Laser;
    [SerializeField] float Speed= 5F;
    [SerializeField] int Lives = 1;
    private float FireRate = 0.15f;
    private float NextFire = 0f;
    [SerializeField] private SpawnManager_2D _SpawnManager_2D;

    // Start is called before the first frame update
    void Start()
    {
        _SpawnManager_2D = GameObject.Find("spawnManager").GetComponent<SpawnManager_2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > NextFire)
        {
            FireLaser();
        }
        CalculateMovment();
    }

    private void FireLaser()
    {
       
            NextFire = Time.time + FireRate;
            Instantiate(Laser, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        
    }
  

    private void CalculateMovment()
    {
        float Horzintal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");


        transform.Translate(Horzintal * Speed * Time.deltaTime, Vertical * Speed * Time.deltaTime, 0);

     
/*

        if (transform.position.y > 4)
        {
            transform.position = new Vector3(transform.position.x, 4, 0);
        }
        if (transform.position.y < -3)
        {
            transform.position = new Vector3(transform.position.x, -3, 0);
        }*/


  /*      transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3, 4), 0);


        if (transform.position.x > 8)
        {
            transform.position = new Vector3(8, transform.position.y, 0);
        }
        if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8, transform.position.y, 0);
        }
*/
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, -8, 8), Mathf.Clamp(transform.position.y, -3, 4),  0);
    }

    public void Damage()
    {
        Lives--;
        if (Lives == 0)
        {
            Destroy(this.gameObject);
            _SpawnManager_2D.PlayerDeath();
        }


    }
}
