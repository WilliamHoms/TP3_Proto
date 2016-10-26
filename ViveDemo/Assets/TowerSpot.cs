using UnityEngine;
using System.Collections;

public class TowerSpot : MonoBehaviour {

    void OnTriggerEnter(Collider col) {

        if (col.gameObject.CompareTag("Arrow")) {
            Debug.Log("CONTRUCTION");
            BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();

            if (bm.selectedTower != null) {
                ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
                if (sm.money < bm.selectedTower.GetComponent<Tower>().cost) {
                    Debug.Log("Not Enough money!");
                    return;    
                }
                sm.money -= bm.selectedTower.GetComponent<Tower>().cost;
                Instantiate(bm.selectedTower, transform.parent.position, transform.parent.rotation);
                Destroy(transform.parent.gameObject);
            }

        }
    }
}
