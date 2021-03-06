﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour {

    float maxGravDist = 45f;
    public float gravity = 1.0f;
    private GameObject[] planets;

	void Start ()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
	}
	
	void Update ()
    {
        foreach (GameObject p in planets)
        {
            float dist = Vector3.Distance(p.transform.position, transform.position);
            if (dist <= maxGravDist)
            {
                var v = p.transform.position - transform.position;
                GetComponent<Rigidbody2D>().AddForce(v.normalized * (gravity - dist / maxGravDist) * maxGravDist);
            }
        }
	}
}
