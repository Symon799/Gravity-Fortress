using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public Vector2 direction = new Vector2(1, 0);
    private GameObject player;
    float maxGravDist = 45f;
    private GameObject[] planets;


    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position;
        planets = GameObject.FindGameObjectsWithTag("Planet");
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GetComponent<Rigidbody2D>().simulated = true;
            GetComponent<Rigidbody2D>().AddForce(transform.right * 2500f);
        }
        else if (!GetComponent<Rigidbody2D>().simulated)
        {
            transform.position = player.transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
            transform.up = -transform.right;
        }

        //Vector3 moveDirection = gameObject.transform.position - _origPos;
        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity.normalized;
        if (moveDirection != Vector3.zero && GetComponent<Rigidbody2D>().velocity.magnitude > 1.5f)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
