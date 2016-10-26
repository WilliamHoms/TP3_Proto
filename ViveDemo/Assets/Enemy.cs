using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject pathGo;

	Transform targetPathNode;
	int pathNodeIndex =0;

	public float speed = 5f;

	public float health = 10f;

	public int moneyValue = 1;

	// Use this for initialization
	void Start () {
		pathGo = GameObject.Find ("Path");
	
	}

    void GetNextPathNode()
    {
        if (pathNodeIndex < pathGo.transform.childCount)
        {
            targetPathNode = pathGo.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        else {
            targetPathNode = null;
            ReachedGoal();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (targetPathNode == null) {
			GetNextPathNode ();
			if (targetPathNode == null) {
				ReachedGoal ();
                return;
			}
		}
		Vector3 dir = targetPathNode.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distThisFrame) {
			targetPathNode = null;
		} else {
			transform.Translate (dir.normalized * distThisFrame,Space.World);
			Quaternion targetRotation = Quaternion.LookRotation (dir);
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, 5 * Time.deltaTime);
		}
	}

	void ReachedGoal(){
		GameObject.FindObjectOfType<ScoreManager> ().Loselife ();
		Destroy (gameObject);
	}

	public void TakeDamage (float damage){
		health -= damage;
		if (health <= 0) {
			Die ();
		}
	}

	public void Die(){ 
		GameObject.FindObjectOfType<ScoreManager> ().money += moneyValue;
		Destroy (gameObject);
	}
}
