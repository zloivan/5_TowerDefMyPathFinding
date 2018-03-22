using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {
    
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    private void Update()
    {
        PrintingCoordinates();
        HanddleCubesPositioning();
    }

    private void HanddleCubesPositioning()
    {
        int gridSize = waypoint.GridSize;
      
        transform.position = new Vector3(
            waypoint.GridPoss.x * waypoint.GridSize,
            0f,
            waypoint.GridPoss.y * waypoint.GridSize
            );
    }

    private void PrintingCoordinates()
    {
        int gridSize = waypoint.GridSize;

        TextMesh CubeLabel = gameObject.GetComponentInChildren<TextMesh>();
       
        if (CubeLabel != null)
        {
            string labelText = "[" + waypoint.GridPoss.x.ToString() + "," + waypoint.GridPoss.y.ToString() + "]";
            CubeLabel.text =labelText;
            
            gameObject.name = "Waypoint:" +labelText;
        }
    }
}
