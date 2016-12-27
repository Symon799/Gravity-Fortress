using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public int hp = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Damage(int damageCount)
    {
        hp -= damageCount;
        if (hp <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShotScript shot = collision.gameObject.GetComponent<ShotScript>();
        if (shot)
        {
            Damage(shot.damage);
            Destroy(shot.gameObject);
        }
    }
}
