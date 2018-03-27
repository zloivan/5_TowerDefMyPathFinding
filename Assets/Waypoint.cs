using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public bool isExplored=false;
    public Waypoint exploredBy;
    const int gridSize = 10;
 

   
    public int GridSize
    {
        get { return gridSize; }
    }

    public Vector2Int GridPoss
    {
        get
        {
            return new Vector2Int
                (
                Mathf.RoundToInt(transform.position.x / gridSize),
                Mathf.RoundToInt(transform.position.z / gridSize)
                );
        }
    }
    
    void Update ()
    {
       
	}

    
}
