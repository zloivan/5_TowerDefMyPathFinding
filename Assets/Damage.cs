using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    // Use this for initialization
    [SerializeField] int hitPoints=10;
    bool isAlive=true;
    [SerializeField] ParticleSystem enemyExplosion;
    private void OnParticleCollision(GameObject other)
    {
        HandleHitings();
        CheckIfAlive();
        
    }

    private void HandleHitings()
    {
        hitPoints--;
    }
    private void CheckIfAlive()
    {
        if (hitPoints<1)
        {
            isAlive = false;
        }
    }


    void Update ()
    {
        if (isAlive==false)
        {
            StartDeathSequence();
        }
	}
    private void StartDeathSequence()
    {
        Vector3 explosionPosition = transform.position + Vector3.up * 4.5f;
        Instantiate(enemyExplosion, explosionPosition, Quaternion.identity);
        //Instantiate()
        Destroy(gameObject);
    }
}
