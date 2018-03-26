using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

   
    
    [SerializeField] float EnemyMovementSpeed=1f;
    Vector3 nextPosition;
    List<Waypoint> path;
    int stepNumber=1;
    // Use this for initialization
    void Start ()
    {
        
        path = FindObjectOfType<PathFinder>().GetPath();
        
        transform.position = path[0].transform.position;
        nextPosition = path[1].transform.position;  

       // StartCoroutine(MoveThrowWaypoints(path));
    }

    //private IEnumerator MoveThrowWaypoints(List<Waypoint> path)
    //{
        
    //    foreach (var item in path)
    //    {
            
    //        nextTransform = item.transform.position;
    //        yield return new WaitForSeconds(EnemyMovementSpeed);
    //    }
    //    print("Finished patrol at :" + path[path.Count - 1].name);// todo delete log
    //}

  

    private void Update()
    {
        if (Vector3.Distance(transform.position,nextPosition)<float.Epsilon)
        {
            nextPosition = GoNextWaypoint();
        }
        transform.position = Vector3.MoveTowards(transform.position,nextPosition,Time.deltaTime*EnemyMovementSpeed*10f);
    }

    private Vector3 GoNextWaypoint()
    {
        if (stepNumber< path.Count-1)
        {
            stepNumber++;
        }
        
        return path[stepNumber].transform.position;
    }
}
