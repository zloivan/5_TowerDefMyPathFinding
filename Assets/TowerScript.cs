using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {
    //todo check if enemy is flying
    
    [SerializeField] float towerRange=10f;
    EnemyMovement[] allEnemies;
    // Use this for initialization
	void Start ()
    {
        allEnemies = FindObjectsOfType<EnemyMovement>();
	}
    EnemyMovement GetClosesd()
    {
        EnemyMovement closesd = allEnemies[0];
        foreach (var enemy in allEnemies)
        {
            
            closesd=    FindClosesdOfTwo(closesd,enemy);
        }
        return closesd;
    }

    private EnemyMovement FindClosesdOfTwo(EnemyMovement positionA, EnemyMovement positionB)
    {
        if (positionA == null)
        {
            return positionB;
        }
        else if (positionB==null)
        {
            return positionA;
        }
        
            
        
        float distanceA =Vector3.Distance(transform.position,positionA.transform.position);
        float distanceB = Vector3.Distance(transform.position,positionB.transform.position);
        if (distanceA>distanceB)
        {
            return positionB;
        }
        else
        {
            return positionA;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        EnemyMovement closesdEnemy = GetClosesd();
        if (closesdEnemy!=null)
        {
            transform.Find("Tower_A_Top").LookAt(closesdEnemy.transform);
            CheckRange(closesdEnemy.transform); 
        }
        else
        {
            AttackEnemy(false);
        }
        
	}

   

    private void CheckRange(Transform enemyTransform) //limit max range of towers
    {

        
        if (Vector3.Distance(transform.position, enemyTransform.position)<=towerRange) //tower check if enemy is in range
        {
            AttackEnemy(true);
            
        }
        else
        {
            AttackEnemy(false);
        }
       
       
        //if enemy is dead stop attack
    }

    private void AttackEnemy(bool attack)
    {
        var bulletsParticles = transform.Find("Tower_A_Top/Bullets").GetComponent<ParticleSystem>(); //string name
        var emmisionModule = bulletsParticles.emission;
        emmisionModule.enabled = attack;

    }
}
