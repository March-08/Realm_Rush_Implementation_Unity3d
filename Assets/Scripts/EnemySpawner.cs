using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    [SerializeField] float secondsBetweenSpaens=2f;
    [SerializeField] EnemyMovement enemyPrefab;

    void Start(){

        StartCoroutine(SpawnEnemy());
        
    }

    IEnumerator SpawnEnemy() {
        yield return new WaitForSeconds(secondsBetweenSpaens);
        Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
