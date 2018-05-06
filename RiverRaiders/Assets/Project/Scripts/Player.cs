using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float horizontalSpeed = 3f;
    public float vertcalSpeed = 1f;
    public float horizontalLimit = 2.8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Move the player.
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, vertcalSpeed);

        // Keep the player within bounds.
        if (transform.position.x > horizontalLimit)
        {
            transform.position = new Vector2(horizontalLimit, transform.position.y);
        } else if (transform.position.x < -horizontalLimit)
        {
            transform.position = new Vector2(-horizontalLimit, transform.position.y);
        }
	}
}
