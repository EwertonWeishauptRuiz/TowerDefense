using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform enemyPrefab, spawnLocation;    
    
    public float timeBetweennWaves, countdownNextWave;

    int waveIndex;
    
    // Use this for initialization
	void Start () {
               
	}
	
	// Update is called once per frame
	void Update () {
        if(countdownNextWave <= 0){
            StartCoroutine(SpawnWave());
            countdownNextWave = timeBetweennWaves;
        }

        countdownNextWave -= Time.deltaTime;
	}
    
    IEnumerator SpawnWave(){
        // Increment the wave number
        waveIndex++;
        for (int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(.5f);
        }
        
    }
    
    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation);
    }
}
