using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public float shootingRate = 0.5f;
    public Transform shotPrefab;

    private float lastTimeShot;

	// Use this for initialization
	void Start () {
        lastTimeShot = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (lastTimeShot > 0)
            lastTimeShot -= Time.deltaTime;
	}

    public bool CanAttack()
    {
        return lastTimeShot <= 0f;
    }

    public void Attack ()
    {
        if (CanAttack())
        {
            lastTimeShot = shootingRate;
            var shotTransform = Instantiate(shotPrefab) as Transform;
            //TODO: placer la flèche légèrement décalée en fonction du sens
            //      dans lequel est tourné le joueur
            shotTransform.position = transform.position;
            shotTransform.position += this.transform.right;
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (!move)
                move.direction = this.transform.right;
        }
    }
}
