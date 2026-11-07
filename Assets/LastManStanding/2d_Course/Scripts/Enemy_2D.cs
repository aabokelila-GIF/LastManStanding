using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy_2D : MonoBehaviour
{
    [SerializeField] Animator m_Animator;
    [SerializeField] float Speed = 1f;
    // [SerializeField] GameObject Laser;
    [SerializeField] GameObject Laser_Prefab;
    private Player_2D player;
    [SerializeField] AudioSource m_AudioSource;


    float canfire = 0f;
    private float FireRate = 3f;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
      player =  GameObject.Find("Player").GetComponent<Player_2D>();
        m_AudioSource = GetComponent<AudioSource>();
        if (player== null )
        {
            Debug.Log("Help");
        }
        if (m_Animator == null)
        {
            Debug.Log("No Anim");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > canfire)
        {
            FireRate = Random.RandomRange(3f, 7f);
            canfire = Time.time + FireRate;
            GameObject EnemyLaser= Instantiate (Laser_Prefab,transform.position, Quaternion.identity);
            Laser [] lasers = EnemyLaser.GetComponentsInChildren<Laser>();
            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }

        }
        CalcuateMovement();

    }

    private void CalcuateMovement()
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
            m_Animator.SetTrigger("Explode");
            Speed = 0.25f;
            m_AudioSource.Play();
            Destroy(this.gameObject,2.7f);

        }


        if (other.gameObject.CompareTag("Laser"))
        {

            player.AddSocre(10);
            m_Animator.SetTrigger("Explode");
            Speed = 0.25f;
            m_AudioSource.Play();

            Destroy(other.gameObject);
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.7f);
        }

    }
}
