using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public Vector2 direction = new Vector2(1, 0);
    float maxGravDist = 45f;
    private GameObject[] planets;

    // Use this for initialization
    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        GetComponent<Rigidbody2D>().AddForce(transform.right * 2500f);
    }

    void Update()
    {
        foreach (GameObject p in planets)
        {

            Quaternion rotation = Quaternion.LookRotation(planets[0].transform.position - transform.position, transform.TransformDirection(Vector3.forward));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            //float dist = Vector3.Distance(p.transform.position, transform.position);
            //if (dist <= maxGravDist)
            
        }
    }
}
