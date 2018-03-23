using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

   
    PathFinder pathfinder;
    [SerializeField] float EnemyMovementSpeed=1f;
    

	// Use this for initialization
	void Start ()
    {
        List<Waypoint> path = FindObjectOfType<PathFinder>().GetPath();
        StartCoroutine(MoveThrowWaypoints(path));
    }

    private IEnumerator MoveThrowWaypoints(List<Waypoint> path)
    {
        
        foreach (var item in path)
        {
            transform.position = item.transform.position;
            yield return new WaitForSeconds(EnemyMovementSpeed);
        }
        print("Finished patrol at :" + path[path.Count - 1].name);// todo delete log
    }


}
