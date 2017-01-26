using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkWeaponScript : NetworkBehaviour {

    public float shootingRate = 0.5f;
    public Transform shotPrefab;
    public int shots_left;
    public int shots_max = 5;

    private float lastTimeShot;

	// Use this for initialization
	void Start () {
        lastTimeShot = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;
        if (lastTimeShot > 0)
            lastTimeShot -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
            CmdAttack();
    }

    public bool CanAttack()
    {
        return lastTimeShot <= 0f && shots_left > 0;
    }

    [Command]
    void CmdAttack ()
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
            NetworkServer.Spawn(this.gameObject);
            if (!move)
                move.direction = this.transform.right;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShotScript shot = collision.gameObject.GetComponent<ShotScript>();
        if (shot && shot.is_land && shots_left < shots_max)
        {
            shots_left++;
            Destroy(shot.gameObject);
        }
    }
}
