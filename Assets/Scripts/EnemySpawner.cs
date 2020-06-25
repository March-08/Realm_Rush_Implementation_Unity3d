using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    [SerializeField] float secondsBetweenSpaens=2f;
    [SerializeField] EnemyMovement enemyPrefab;

    void Start(){

        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies() {
        yield return new WaitForSeconds(secondsBetweenSpaens);
        Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
