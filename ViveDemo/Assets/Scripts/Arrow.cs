using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	private bool isAttached = false;

	private bool isFired = false;

	void OnTriggerStay() {
		AttachArrow ();


	}

	void OnTriggerEnter (Collider col){
		AttachArrow ();
		if (col.gameObject.CompareTag ("Enemy")) {
			col.transform.GetComponent<Enemy> ().TakeDamage (10);
			Debug.Log ("HIT");
            Destroy(gameObject);

		}
        if (col.gameObject.CompareTag("Untagged")) {
            Debug.Log("Arrow destroyed by " + col.transform.name);
            Destroy(gameObject);
        }
        //TODO: Make the arrows destroy on collision with the decor;
	}

	void Update(){
		if (isFired) {
			transform.LookAt (transform.position + transform.GetComponent<Rigidbody> ().velocity);
		}
	}

	public void Fired(){
		isFired = true;
	}

	private void AttachArrow(){
		var device = SteamVR_Controller.Input ((int)ArrowManager.Instance.trackedObj.index);
		if (!isAttached && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
			ArrowManager.Instance.AttachBowToArrow ();
			isAttached = true;
		}
	}


}
