using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public Vector2 direction = new Vector2(1, 0);
    float maxGravDist = 45f;
    private GameObject[] planets;
    private Vector3 prevPos;
    private Vector3 currPos;


    // Use this for initialization
    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        GetComponent<Rigidbody2D>().AddForce(transform.right * 2500f);
        prevPos = gameObject.transform.position;
        currPos = gameObject.transform.position;
    }

    void Update()
    {
        //Vector3 moveDirection = gameObject.transform.position - _origPos;
        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity.normalized;
        if (moveDirection != Vector3.zero && GetComponent<Rigidbody2D>().velocity.magnitude > 3)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
