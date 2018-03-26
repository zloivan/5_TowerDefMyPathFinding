using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetection : MonoBehaviour {

    Color originalColor;
    MeshRenderer renderer = new MeshRenderer();
    [SerializeField] Color highlightColor;
	// Use this for initialization
	void Start () {
        renderer = transform.Find("Block_Friendly").GetComponent<MeshRenderer>();
        originalColor = renderer.material.color;
	}
    private void OnMouseOver()
    {

        renderer.material.color = highlightColor;
        
        
    }

    private void OnMouseExit()
    {
        renderer.material.color = originalColor;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
