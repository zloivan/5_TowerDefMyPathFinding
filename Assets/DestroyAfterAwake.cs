using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAwake : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject,2f);
	}
	
	// Update is called once per frame
	
}
