using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public bool isExplored=false;
    const int gridSize = 10;

    Vector2Int gridPosition;
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
    // Update is called once per frame
    void Update () {
		
	}

    internal void ChangeColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
