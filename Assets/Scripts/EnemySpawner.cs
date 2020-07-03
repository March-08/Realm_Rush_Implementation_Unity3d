using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour{
    
    [Range(0.1f, 12f)]
    [SerializeField] float secondsBetweenSpaens=4f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTranform;
    [SerializeField] Text numberOfEnemiesText;
    [SerializeField] AudioClip spawnedEnemySFX;
    private int numberOfEnemies = 0;


    void Start(){
        
        numberOfEnemiesText.text = numberOfEnemies.ToString();
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies() {

        while (true) {
            var enemy = Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);

            UpdateNumberEnemiesText();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);

            enemy.transform.parent = enemyParentTranform;
            yield return new WaitForSeconds(secondsBetweenSpaens);
        }

    }

    private void UpdateNumberEnemiesText() {
        numberOfEnemies += 1;
        numberOfEnemiesText.text = numberOfEnemies.ToString();
    }

}
