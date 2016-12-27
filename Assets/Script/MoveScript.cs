using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    public Vector2 speed = new Vector2(5, 5);
    public Vector2 direction = new Vector2(1, 0);

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

	// Use this for initialization
	void Start () {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
        
    }

    private void FixedUpdate()
    {
        if (rigidbodyComponent == null)
        {
            rigidbodyComponent = GetComponent<Rigidbody2D>();
        }
        rigidbodyComponent.velocity = movement;
    }
}
