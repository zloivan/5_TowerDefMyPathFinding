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
    Waypoint searchCenter;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        return path;
    }
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
            searchCenter = queue.Dequeue();
            CheckForEndpoint();
            FindNeighbors();
        }
    }

    private void CheckForEndpoint()
    {
        if (searchCenter.GridPoss == endPoint.GridPoss)
        {
            Debug.LogWarning("End point is reached.");
            isSearching = false;
            BuildPath();
        }
    }

    private void BuildPath()
    {
        //path.Add(endPoint.exploredBy);
       
        Waypoint last = endPoint;
        while (last.GridPoss!=startPoint.GridPoss)
        {
            path.Add(last);
            print("added to stack:" + last);//todo remove log
            last = last.exploredBy;
        }
        path.Add(startPoint);
        path.Reverse();
        var enemy=    FindObjectOfType<EnemyMovement>();
        enemy.enabled = true;
        foreach (var item in path)
        {
            print("My path: "+item); // todo remove log
        }
    }

    private void FindNeighbors()
    {
        if (!isSearching) { return; }
     
        foreach (var direction in allDirections)
        {
            var neighborPos = searchCenter.GridPoss + direction;
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
            neighbor.exploredBy = searchCenter;
            print(neighbor+" explored by: "+neighbor.exploredBy);
           
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
