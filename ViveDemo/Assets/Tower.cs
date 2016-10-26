using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	Transform turretTransform;

	Transform bulletSpawnPos;

	float range = 50f;
	public GameObject bulletPrefab;

    public int cost = 5;

	float fireCooldown =2f;
	float fireCooldownLeft = 0;

	void Start () {
		turretTransform = transform.Find ("Turret");

		bulletSpawnPos = gameObject.transform.GetChild (1).transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () {
	
		Enemy[] enemies = GameObject.FindObjectsOfType<Enemy> ();

		Enemy nearestEnemy = null;
		float dist = Mathf.Infinity;

		foreach (Enemy e in enemies) {
			float d = Vector3.Distance (this.transform.position, e.transform.position);
			if (nearestEnemy == null || d < dist) {
				nearestEnemy = e;
				dist = d;
			}
		}

		if (nearestEnemy == null) {
			Debug.Log ("No Ennemies");
			return;
		}

		Vector3 dir = nearestEnemy.transform.position - this.transform.position;
		Quaternion lookRot = Quaternion.LookRotation (dir);

		turretTransform.rotation = Quaternion.Euler (0, lookRot.eulerAngles.y, 0);

		fireCooldownLeft -= Time.deltaTime;
		if (fireCooldownLeft <= 0 && dir.magnitude <= range) {
			fireCooldownLeft = fireCooldown;
			ShootAt (nearestEnemy);
		}
	}

	void ShootAt (Enemy e){
		GameObject bulletGo = (GameObject)Instantiate (bulletPrefab, bulletSpawnPos.transform.position, bulletSpawnPos.transform.rotation);

		Bullet b = bulletGo.GetComponent<Bullet>();
		b.target = e.transform;
	}
}
