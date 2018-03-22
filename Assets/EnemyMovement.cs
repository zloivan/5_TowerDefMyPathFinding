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
        print("End of patroll");
    }

    private IEnumerator MoveThrowWaypoints()
    {
        print("Patrol starts at: " + waypoints[0].name);
        foreach (var item in waypoints)
        {
            transform.position = item.transform.position;
            yield return new WaitForSeconds(EnemyMovementSpeed);
        }
        print("Finished patrol at :"+waypoints[ waypoints.Count-1].name);
    }

    
}
