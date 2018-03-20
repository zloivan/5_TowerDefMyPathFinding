using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {
    [Range(1f,20f)]
    [SerializeField] float GridSize = 10f;
    TextMesh CubeLabel;
    private void Start()
    {
        
    }
    private void Update()
    {
        PrintingCoordinates();
        HanddleCubesPositioning();
    }

    private void HanddleCubesPositioning()
    {
        Vector3 NewPosition;
        NewPosition.x = Mathf.RoundToInt(transform.position.x / GridSize) * GridSize;
        NewPosition.z = Mathf.RoundToInt(transform.position.z / GridSize) * GridSize;
        transform.position = new Vector3(NewPosition.x, 0f, NewPosition.z);
    }

    private void PrintingCoordinates()
    {
        CubeLabel = gameObject.GetComponentInChildren<TextMesh>();
       
        if (CubeLabel != null)
        {
            string CoordinatesX = Mathf.RoundToInt(transform.position.x / GridSize).ToString();
            string CoordinatesZ = Mathf.RoundToInt(transform.position.z / GridSize).ToString();
            CubeLabel.text = "[" + CoordinatesX + "," + CoordinatesZ + "]";
            //changing name of gameobject acoarding to coardinates.
            gameObject.name = "Waypoint:(" + CoordinatesX + "," + CoordinatesZ + ")";
        }
    }
}
