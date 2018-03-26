using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    [SerializeField] Waypoint startPoint, endPoint;
    Vector2Int[] allDirections =
     {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left,
    };
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    bool isRuning = true;
    Waypoint searchCenter;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        if (path.Count<1)
        {
            LoadBlocks();
            PaintStartAndEnd();
            BreathFirst();
            BuildPath(); 
        }
        return path;
    }
   

    private void BreathFirst()
    {
        
        queue.Enqueue(startPoint);
        startPoint.isExplored = true;
        while (queue.Count > 0 && isRuning)
        {
            searchCenter = queue.Dequeue();
            CheckForEndpoint();
            FindNeighbors();
        }
    }

    private void CheckForEndpoint()
    {
        if (searchCenter.GridPoss == endPoint.GridPoss)
        {
            isRuning = false;
        }
    }

    private void BuildPath()
    {
       
        Waypoint last = endPoint;
        while (last.GridPoss!=startPoint.GridPoss)
        {
            path.Add(last);
            last = last.exploredBy;
        }
        path.Add(startPoint);
        path.Reverse();
       
       
    }

    private void FindNeighbors()
    {
        if (!isRuning) { return; }
     
        foreach (var direction in allDirections)
        {
            Vector2Int neighborPos = searchCenter.GridPoss + direction;
            if (grid.ContainsKey(neighborPos))
            {
                QueingNeighbors(neighborPos);
            }
        }
    }

    private void QueingNeighbors(Vector2Int neighborPos)
    {
        Waypoint neighbor = grid[neighborPos];

        if (neighbor.isExplored)
        {
            //do nothing
        }
        else
        {
            neighbor.isExplored = true;
            queue.Enqueue(neighbor);
            neighbor.exploredBy = searchCenter;
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
    }
}
