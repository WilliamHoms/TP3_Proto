using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 50f;
	public Transform target;
	public float damage = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (target == null) {
			Destroy (gameObject);
			return;
			
		}
		Vector3 dir = target.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distThisFrame) {
			DoBulletHit ();
		} else {
			transform.Translate (dir.normalized * distThisFrame,Space.World);
			Quaternion targetRotation = Quaternion.LookRotation (dir);
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, 5 * Time.deltaTime);
		}
	
	}

	void DoBulletHit(){
		target.GetComponent<Enemy> ().TakeDamage (damage);
		Destroy (gameObject);
	}
}
