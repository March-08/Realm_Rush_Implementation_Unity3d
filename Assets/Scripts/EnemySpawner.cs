using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    
    [Range(0.1f, 12f)]
    [SerializeField] float secondsBetweenSpaens=4f;
    [SerializeField] EnemyMovement enemyPrefab;

    void Start(){

        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies() {

        while (true) {
            Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpaens);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
