using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour{


    [SerializeField] int hitPoints=10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyDamageSFX;
    [SerializeField] AudioClip enemyDeathSFX;
    AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        if (GameObject.Find("VFXContainer")){
            deathParticlePrefab.transform.SetParent(GameObject.Find("VFXContainer").transform);

        }
        else {
            GameObject VFXContainer=new GameObject("VFXContainer");
            deathParticlePrefab.transform.SetParent(VFXContainer.transform);

        }

    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (hitPoints < 1) {
            KillEnemy();
        }
    }

    void ProcessHit() {
        hitPoints -= 1;
        audioSource.PlayOneShot(enemyDamageSFX);
        print("damage");
        hitParticlePrefab.Play();
    }

    public void KillEnemy() {
        ParticleSystem vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, FindObjectOfType<Camera>().transform.position);
    }


}
