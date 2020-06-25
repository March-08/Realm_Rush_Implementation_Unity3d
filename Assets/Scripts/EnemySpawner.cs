using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    [SerializeField] float secondsBetweenSpaens=4f;
    [SerializeField] EnemyMovement enemyPrefab;

    void Start(){

        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies() {

        while (true) {  //sempre
            yield return new WaitForSeconds(secondsBetweenSpaens);
            Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
