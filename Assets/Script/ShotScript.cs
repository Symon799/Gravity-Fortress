using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    public int damage = 1;
    public bool is_land = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnCollisionEnter2D()
    {
        is_land = true;
        GetComponent<Rigidbody2D>().fixedAngle = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //GetComponent<Rigidbody2D>().simulated = false;
        Destroy(gameObject, 5);
    }
}