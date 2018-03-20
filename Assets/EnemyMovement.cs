using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> waypoints;

    [SerializeField] float EnemyMovementSpeed=1f;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(MoveThrowWaypoints());
      
    }

    private IEnumerator MoveThrowWaypoints()
    {
        foreach (var item in waypoints)
        {
            transform.position = item.transform.position;
            yield return new WaitForSeconds(EnemyMovementSpeed);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
