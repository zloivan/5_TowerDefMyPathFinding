using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    [SerializeField] Waypoint startPoint, endPoint;
    
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	// Use this for initialization
	void Start ()
    {
        LoadBlocks();
        PaintStartAndEnd();
        FindNeighbors(startPoint);
	}

    private void FindNeighbors(Waypoint waypoint)
    {
        Vector2Int[] allSides =
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.right,
            Vector2Int.left,
        };
        foreach (var item in allSides)
        {

            try
            {
                grid[waypoint.GridPoss + item].ChangeColor(Color.blue);
            }
            catch (Exception)
            {

                
            }
            
           
        }
        
    }

    

    private void PaintStartAndEnd()
    {
        grid[startPoint.GridPoss].ChangeColor(Color.green);
        grid[endPoint.GridPoss].ChangeColor(Color.red);
    }

    private void LoadBlocks()
    {
        var allBlocks = FindObjectsOfType<Waypoint>();
        foreach (var item in allBlocks)
        {
            if (!grid.ContainsKey(item.GridPoss))
            {
                grid.Add(item.GridPoss, item);
            }
            else
            {
                Debug.LogWarning(item.GridPoss + " is found in world more than once.");
            }

           
        }
        print(grid.Count);

    }


   
}
