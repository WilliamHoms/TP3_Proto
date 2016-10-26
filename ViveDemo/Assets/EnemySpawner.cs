using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    float spawnCD = 1.2f;
    float spawnCDRemaining = 0;

    [System.Serializable]
    public class WaveComponent{
        public GameObject enemyPrefab;
        public int num;
        [System.NonSerialized]
        public int spawned = 0;
        }
    public WaveComponent[] waveComps;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        spawnCDRemaining -= Time.deltaTime;

        if (spawnCDRemaining < 0) {
            spawnCDRemaining = spawnCD;
            bool didSpawn = false;
            foreach (WaveComponent wc in waveComps) {
                if (wc.spawned < wc.num)
                {
                    Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);
                    wc.spawned++;
                    didSpawn = true;
                    break;
                }
            }

            if (didSpawn == false)
            {
                //wave is complete
                //instantiate next wave object
                Destroy(gameObject);
            }
        }
	
	}
}
