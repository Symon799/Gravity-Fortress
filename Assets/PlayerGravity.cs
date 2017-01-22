using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour {

    float maxGravDist = 45f;
    public float gravity = 1.0f;
    private GameObject[] planets;

    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
    }

    void Update()
    {

        Quaternion rotation = Quaternion.LookRotation(planets[0].transform.position - transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
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
