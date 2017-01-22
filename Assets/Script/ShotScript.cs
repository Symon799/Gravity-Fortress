using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    public int damage = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnCollisionEnter2D()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        //Destroy(gameObject);
    }
}