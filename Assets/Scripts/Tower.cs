using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour{
    //mod B

    //parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] float attackRange=10f;

    //state
    [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update(){

        SetTargetEnemy();

        if (targetEnemy) {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else {
            Shoot(false);
        }
        
    }

    private void SetTargetEnemy() {

        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach(EnemyDamage testEnemy in sceneEnemies) {
            closestEnemy = GetClosest(closestEnemy,testEnemy.transform);
        }
        targetEnemy = closestEnemy;

    }

    private Transform GetClosest(Transform tf1, Transform tf2) {
        var distance1=Vector3.Distance(transform.position, tf1.position);
        var distance2=Vector3.Distance(transform.position, tf2.position);
        if (distance1 <= distance2) {
            return tf1;
        }
        return tf2;

    }

    void FireAtEnemy() {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if(distanceToEnemy <= attackRange) {
            Shoot(true);
        }
        else {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive) {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;

    }
}
