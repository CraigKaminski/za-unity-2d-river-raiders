using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

    public GameObject target;
    public float verticalOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(
            0,
            target.transform.position.y + verticalOffset,
            transform.position.z
        );
	}
}
