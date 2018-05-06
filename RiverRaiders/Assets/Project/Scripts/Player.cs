﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject bulletPrefab;
    public float horizontalSpeed = 3f;
    public float vertcalSpeed = 1f;
    public float horizontalLimit = 2.8f;
    public float bulletSpeed = 2f;

    private bool fired = false;

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

        if (Input.GetAxis("Fire1") == 1f)
        {
            if (fired == false)
            {
                fired = true;
                GameObject bulletInstance = Instantiate(bulletPrefab);
                bulletInstance.transform.SetParent(transform.parent);
                bulletInstance.transform.position = transform.position;
                bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                Destroy(bulletInstance, 3f);
            }
        } else
        {
            fired = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "EnemyBullet" || otherCollider.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
        }
    }
}
