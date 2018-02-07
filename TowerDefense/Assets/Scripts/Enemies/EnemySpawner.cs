using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [HideInInspector]
    public static int enemiesAlive;

    public WaveManager[] waves;
    
    public Transform spawnLocation;    
    
    public float timeBetweennWaves, countdownNextWave;

    int waveIndex;
	
	void Update () {
        // Will not spawn more enemies, while there are enemies alive
        if(enemiesAlive > 0){
            return;
        }
    
        if(countdownNextWave <= 0){
            StartCoroutine(SpawnWave());
            countdownNextWave = timeBetweennWaves;
            return;
        }

        countdownNextWave -= Time.deltaTime;
	}
    
    IEnumerator SpawnWave(){
        WaveManager wave = waves[waveIndex];  

      // Increment the wave number
        for (int i = 0; i < wave.amountofEnemies; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1 / wave.spawnRate);
        }
        
		waveIndex++;
        
        if(waveIndex == waves.Length){
            print("Level Finished");
            //Make this script disable, so stops spawning
            enabled = false;
        }
    }
    
    void SpawnEnemy(GameObject enemy){
        Instantiate(enemy, spawnLocation.position, spawnLocation.rotation);
        enemiesAlive++;
    }
}
