using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class SpawnManager_2D : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Enemy_Prefab;

    [SerializeField] GameObject EnemyConatier;
    private bool StopSpawning = false;
    void Start()
    {
        StartCoroutine(EnemyPrefabQ(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator EnemyPrefabQ(float Time_Instaniate)
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

    public void PlayerDeath()
    {
        StopSpawning = true;
    }
}
