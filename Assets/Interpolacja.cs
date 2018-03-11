using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolacja : MonoBehaviour {

    public Transform startMarker;
    public Transform endMarker;

    // Use this for initialization
    void Start () {
        float journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
