using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    [SerializeField] float SecondsToSpawn;
    [SerializeField] EnemyMovement enemy;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnEnemy());
	}
    //add courutine
    //every 2 sec spawn enemy
    //forever
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemy,transform.position,Quaternion.identity,transform);
            yield return new WaitForSeconds(SecondsToSpawn);
        }
       
    }
}
