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

        int x = waypoint.GridPoss.x;
        int y = waypoint.GridPoss.y;
      
        Vector2Int[] allSides = new Vector2Int[]
        {
            new Vector2Int(x, y + 1),
            new Vector2Int(x, y - 1),
            new Vector2Int(x + 1, y),
            new Vector2Int(x - 1, y),
        };
        foreach (var item in allSides)
        {
            ColorNeighborWaypoint(item);
        }
    }

    private void ColorNeighborWaypoint(Vector2Int newighberWaypoint)
    {
        if (grid.ContainsKey(newighberWaypoint))
        {
            grid[newighberWaypoint].ChangeColor(Color.blue);
        }
        else
        {
            print("No neighbor at: "+grid[newighberWaypoint]);
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
