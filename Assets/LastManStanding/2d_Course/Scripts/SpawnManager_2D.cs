using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class SpawnManager_2D : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Enemy_Prefab;
    [SerializeField] GameObject [] PowerUps ;

    [SerializeField] GameObject EnemyConatier;
    private bool StopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnEnemyPrefabQ(5));
        StartCoroutine(SpawnTripleShot_PowerUp(7));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemyPrefabQ(float Time_Instaniate)
    {
        while (StopSpawning == false)
        {
            yield return new WaitForSeconds(0.2f);

          Vector3 Enemy_Position = new Vector3(UnityEngine.Random.Range(-7, 7),6,0);


        GameObject EnemyPrefab_New =  Instantiate(Enemy_Prefab,Enemy_Position,quaternion.identity);
            EnemyPrefab_New.transform.parent = EnemyConatier.transform;
            yield return new WaitForSeconds(3);

        }

    }

    IEnumerator SpawnTripleShot_PowerUp(float Time_Instaniate)
    {
        while (StopSpawning == false)
        {
            Vector3 PowerUp_Position = new Vector3(UnityEngine.Random.Range(-7, 7), 6, 0);
            int RandomPowreups = UnityEngine.Random.Range(0, 3);
            yield return new WaitForSeconds(Time_Instaniate);
            Instantiate(PowerUps[RandomPowreups],PowerUp_Position,Quaternion.identity);
        }
    }

    public void PlayerDeath()
    {
        StopSpawning = true;
    }
}
