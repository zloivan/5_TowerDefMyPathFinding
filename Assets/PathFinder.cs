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
    bool isSearching = true;
    Queue<Waypoint> queue = new Queue<Waypoint>();

    // Use this for initialization
    void Start()
    {
        LoadBlocks();
        PaintStartAndEnd();
        Pathfind();
        //FindNeighbors(startPoint);
    }

    private void Pathfind()
    {
        
        queue.Enqueue(startPoint);
        startPoint.isExplored = true;
        while (queue.Count > 0 && isSearching)
        {
            var centertPoint = queue.Dequeue();
            
            print("Searching from:" + centertPoint); //todo delete log
            CheckForEndpoint(centertPoint);
            FindNeighbors(centertPoint);
        }
        print("Searching is finished."); //todo delete log
    }

    private void CheckForEndpoint(Waypoint center)
    {
        if (center.GridPoss == endPoint.GridPoss)
        {
            Debug.LogWarning("End point is reached.");
            isSearching = false;

        }
    }

    private void FindNeighbors(Waypoint from)
    {
        if (!isSearching) { return; }
     
        foreach (var direction in allDirections)
        {
            var neighborPos = from.GridPoss + direction;
            try
            {
                QueingNeighbors(neighborPos);
            }
            catch (Exception)
            {
            }
        }
    }

    private void QueingNeighbors(Vector2Int neighborPos)
    {
        Waypoint neighbor = grid[neighborPos];
        neighbor.ChangeColor(Color.blue); //todo take away color
        if (neighbor.isExplored)
        {
            //do nothing
        }
        else
        {
            neighbor.isExplored = true;
            queue.Enqueue(neighbor);
            print("Queing :"+neighbor);//todo delete log
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
