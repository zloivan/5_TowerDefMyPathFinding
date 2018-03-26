using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrolMove : MonoBehaviour {

    [SerializeField] ParticleSystem bullet;
    Vector3 startPosition;
    float startingTime,distance,time;

    // Use this for initialization
    void Start () {
        distance = 10f;
        time = 3f;
         startPosition = transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up * 2f, Time.deltaTime * 2f);
        startingTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position,startPosition+Vector3.up*distance,Time.deltaTime*distance/time);
        if ( Vector3.Distance(transform.position, startPosition + Vector3.up * 10f) <float.Epsilon )
        {
            print(Time.time-startingTime);
        }
	}
}
