using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorHelper : MonoBehaviour {
    [Range(1f,20f)]
    [SerializeField] float GridSize = 10f;
    private void Update()
    {
        Vector3 NewPosition;

        NewPosition.x = Mathf.RoundToInt(transform.position.x/ GridSize) * GridSize;
        NewPosition.z = Mathf.RoundToInt(transform.position.z / GridSize) * GridSize;
        transform.position = new Vector3(NewPosition.x,0f,NewPosition.z);
    }
}
